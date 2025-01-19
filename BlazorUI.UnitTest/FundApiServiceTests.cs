using BlazorUI.Services;
using Models.DTOs;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http.Json;

namespace BlazorUI.Tests.Services;

public class FundApiServiceTests
{
    private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
    private readonly FundApiService _fundApiService;

    public FundApiServiceTests()
    {
        _mockHttpClientFactory = new Mock<IHttpClientFactory>();
        _fundApiService = new FundApiService(_mockHttpClientFactory.Object);
    }

    [Fact]
    public async Task GetFundsAsync_ReturnsFunds_WhenApiCallIsSuccessful()
    {
        // Arrange
        var expectedFunds = new List<FundDTO>
            {
                new FundDTO { Id = 1, FundName = "Fund 1" },
                new FundDTO { Id = 2, FundName = "Fund 2" }
            };

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(expectedFunds)
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        httpClient.BaseAddress = new Uri("https://localhost:5000");
        _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

        // Act
        var result = await _fundApiService.GetFundsAsync();

        // Assert
        Assert.True(result.Success);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(expectedFunds.Count, result.Data.Count);
    }

    [Fact]
    public async Task GetFundsAsync_ReturnsError_WhenApiCallFails()
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent("Internal Server Error")
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        httpClient.BaseAddress = new Uri("https://localhost:5000");

        _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

        // Act
        var result = await _fundApiService.GetFundsAsync();

        // Assert
        Assert.False(result.Success);
        Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
        Assert.Null(result.Data);
        Assert.Contains("Failed to retrieve funds", result.ErrorMessage);
    }
}
