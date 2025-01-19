using ManageInvestors.Models;
using Models.DTOs;
using System.Net;

namespace BlazorUI.Services
{
    /// <summary>
    /// Wraps response details in a generic ApiResponse<T> object.
    /// </summary>
    public class InvestmentApiService : IInvestmentApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string ApiClientName = "InvestorApi"; // Same name used in Program.cs

        public InvestmentApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets all investments (including their funds).
        /// Corresponds to GET api/investor
        /// Returns ApiResponse with List of Investor.
        /// </summary>
        public async Task<ApiResponse<List<Investment>>> GetInvestmentsAsync(
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<List<Investment>>();

            var response = await httpClient.GetAsync("api/investment", cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                // Non-success (could be 404, 500, etc.)
                apiResponse.Success = false;
                apiResponse.ErrorMessage =
                    $"Failed to retrieve investors. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
                apiResponse.Data = null;
                apiResponse.Completed = true;
                return apiResponse;
            }

            // Success => parse the JSON
            apiResponse.Success = true;
            apiResponse.Data = await response.Content.ReadFromJsonAsync<List<Investment>>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Gets a single Investment by Id.
        /// Corresponds to GET api/investor/{id}
        /// Returns ApiResponse with single Investor.
        /// </summary>
        public async Task<ApiResponse<Investment>> GetInvestmentAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<Investment>();

            var response = await httpClient.GetAsync($"api/investment/{id}", cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    apiResponse.ErrorMessage = $"Investment with FundID {id} not found (404).";
                }
                else
                {
                    apiResponse.ErrorMessage =
                        $"Failed to retrieve investor. HTTP {response.StatusCode}. " +
                        await response.Content.ReadAsStringAsync(cancellationToken);
                }
                apiResponse.Data = null;
                apiResponse.Completed = true;
                return apiResponse;
            }

            apiResponse.Success = true;
            apiResponse.Data = await response.Content.ReadFromJsonAsync<Investment>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Creates a new Investment.
        /// Corresponds to POST api/investor
        /// Returns ApiResponse with the created Investor.
        /// </summary>
        public async Task<ApiResponse<bool>> CreateInvestmentAsync(
            InvestmentDTO newInvestment,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<bool>();

            var response = await httpClient.PostAsJsonAsync("api/investment", newInvestment, cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage =
                    $"Failed to create Investment. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
                apiResponse.Completed = true;
                return apiResponse;
            }

            apiResponse.Success = true;
            apiResponse.Data = response.IsSuccessStatusCode;
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Creates a new Investment.
        /// Corresponds to POST api/investor
        /// Returns ApiResponse with the created Investor.
        /// </summary>
        public async Task<ApiResponse<bool>> UpdateInvestmentAsync(
            InvestmentDTO investment,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<bool>();

            var response = await httpClient.PutAsJsonAsync($"api/investment/{investment.Id}", investment, cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage =
                    $"Failed to update investor. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
                apiResponse.Completed = true;
                return apiResponse;
            }

            apiResponse.Success = true;
            apiResponse.Data = response.IsSuccessStatusCode;
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Deletes an Investment by Id.
        /// Corresponds to DELETE api/investor/{id}
        /// Returns ApiResponse with boolean indicating success.
        /// </summary>
        public async Task<ApiResponse<bool>> DeleteInvestmentAsync(
            int id, bool hardDelete = false,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<bool>();
            var url = hardDelete ? $"api/investment/{id}/hard-delete" : $"api/investment/{id}";
            var response = await httpClient.DeleteAsync(url, cancellationToken);
            apiResponse.StatusCode = response.StatusCode;
            apiResponse.Success = response.IsSuccessStatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.ErrorMessage =
                    $"Failed to delete investor. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
            }

            // True if response.IsSuccessStatusCode, otherwise false
            apiResponse.Data = response.IsSuccessStatusCode;
            apiResponse.Completed = true;
            return apiResponse;
        }
    }
}
