using Models.DTOs;
using System.Net;

namespace BlazorUI.Services
{
    /// <summary>
    /// Wraps response details in a generic ApiResponse<T> object.
    /// </summary>
    public class FundApiService : IFundApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string ApiClientName = "InvestorApi"; // Same name used in Program.cs

        public FundApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets all funds (including their funds).
        /// Corresponds to GET api/fund
        /// Returns ApiResponse with List of Funds.
        /// </summary>
        public async Task<ApiResponse<List<FundDTO>>> GetFundsAsync(
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<List<FundDTO>>();

            var response = await httpClient.GetAsync("api/fund", cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                // Non-success (could be 404, 500, etc.)
                apiResponse.Success = false;
                apiResponse.ErrorMessage =
                    $"Failed to retrieve funds. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
                apiResponse.Data = null;
                apiResponse.Completed = true;
                return apiResponse;
            }

            // Success => parse the JSON
            apiResponse.Success = true;
            apiResponse.Data = await response.Content.ReadFromJsonAsync<List<FundDTO>>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Gets a single fund by Id.
        /// Corresponds to GET api/fund/{id}
        /// Returns ApiResponse with single Funds.
        /// </summary>
        public async Task<ApiResponse<FundDTO>> GetFundAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<FundDTO>();

            var response = await httpClient.GetAsync($"api/fund/{id}", cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    apiResponse.ErrorMessage = $"Fund with ID {id} not found (404).";
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
            apiResponse.Data = await response.Content.ReadFromJsonAsync<FundDTO>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Creates a new fund.
        /// Corresponds to POST api/fund
        /// Returns ApiResponse with the created Fund.
        /// </summary>
        public async Task<ApiResponse<FundDTO>> CreateFundAsync(
            FundDTO newFund,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<FundDTO>();

            var response = await httpClient.PostAsJsonAsync("api/fund", newFund, cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage =
                    $"Failed to create fund. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
                apiResponse.Data = null;
                apiResponse.Completed = true;
                return apiResponse;
            }

            apiResponse.Success = true;
            apiResponse.Data = await response.Content.ReadFromJsonAsync<FundDTO>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Creates a new fund.
        /// Corresponds to POST api/fund
        /// Returns ApiResponse with the created Fund.
        /// </summary>
        public async Task<ApiResponse<FundDTO>> UpdateFundAsync(
            FundDTO fund,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<FundDTO>();

            var response = await httpClient.PutAsJsonAsync($"api/fund/{fund.Id}", fund, cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage =
                    $"Failed to update fund. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
                apiResponse.Data = null;
                apiResponse.Completed = true;
                return apiResponse;
            }

            apiResponse.Success = true;
            apiResponse.Data = await response.Content.ReadFromJsonAsync<FundDTO>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Deletes an fund by Id.
        /// Corresponds to DELETE api/fund/{id}
        /// Returns ApiResponse with boolean indicating success.
        /// </summary>
        public async Task<ApiResponse<bool>> DeleteFundAsync(
            int id, bool hardDelete = false,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<bool>();
            var url = hardDelete ? $"api/fund/{id}" : $"api/fund/{id}/soft-delete";
            var response = await httpClient.DeleteAsync(url, cancellationToken);
            apiResponse.StatusCode = response.StatusCode;
            apiResponse.Success = response.IsSuccessStatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.ErrorMessage =
                    $"Failed to delete fund. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
            }

            // True if response.IsSuccessStatusCode, otherwise false
            apiResponse.Data = response.IsSuccessStatusCode;
            apiResponse.Completed = true;
            return apiResponse;
        }

        public async Task<ApiResponse<List<InvestorDTO>>> GetAllInvestorsByFund(
            int fundId, bool inscludeInvestments = false,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<List<InvestorDTO>>();
            var url = inscludeInvestments
                ? $"api/fund/{fundId}/investors-investments"
                : $"api/fund/{fundId}/investors";
            var response = await httpClient.GetAsync(url, cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage =
                    $"Failed to create fund. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);
                apiResponse.Data = null;
                apiResponse.Completed = true;
                return apiResponse;
            }

            apiResponse.Success = true;
            apiResponse.Data = await response.Content.ReadFromJsonAsync<List<InvestorDTO>>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

    }
}
