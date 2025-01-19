using Models.DTOs;
using System.Net;

namespace BlazorUI.Services
{
    /// <summary>
    /// Wraps response details in a generic ApiResponse<T> object.
    /// </summary>
    public class InvestorApiService : IInvestorApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string ApiClientName = "InvestorApi"; // Same name used in Program.cs

        public InvestorApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets all investors (including their funds).
        /// Corresponds to GET api/investor
        /// Returns ApiResponse with List of Investor.
        /// </summary>
        public async Task<ApiResponse<List<InvestorDTO>>> GetInvestorsAsync(
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<List<InvestorDTO>>();

            var response = await httpClient.GetAsync("api/investor", cancellationToken);
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
            apiResponse.Data = await response.Content.ReadFromJsonAsync<List<InvestorDTO>>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        public async Task<ApiResponse<List<InvestorDTO>>> GetInvestorsAndInvestmentsAsync(
      CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<List<InvestorDTO>>();

            var response = await httpClient.GetAsync("api/investor/investments", cancellationToken);
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
            apiResponse.Data = await response.Content.ReadFromJsonAsync<List<InvestorDTO>>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }


        /// <summary>
        /// Gets a single investor by Id.
        /// Corresponds to GET api/investor/{id}
        /// Returns ApiResponse with single Investor.
        /// </summary>
        public async Task<ApiResponse<InvestorDTO>> GetInvestorAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<InvestorDTO>();

            var response = await httpClient.GetAsync($"api/investor/{id}", cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    apiResponse.ErrorMessage = $"Investor with ID {id} not found (404).";
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
            apiResponse.Data = await response.Content.ReadFromJsonAsync<InvestorDTO>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Gets a single investor by Id.
        /// Corresponds to GET api/investor/{id}
        /// Returns ApiResponse with single Investor.
        /// </summary>
        public async Task<ApiResponse<InvestorDTO>> GetInvestorAndInvestmentsAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<InvestorDTO>();

            var response = await httpClient.GetAsync($"api/investor/{id}/investments", cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    apiResponse.ErrorMessage = $"Investor with ID {id} not found (404).";
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
            apiResponse.Data = await response.Content.ReadFromJsonAsync<InvestorDTO>(
                cancellationToken: cancellationToken);
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Creates a new investor.
        /// Corresponds to POST api/investor
        /// Returns ApiResponse with the created Investor.
        /// </summary>
        public async Task<ApiResponse<bool>> CreateInvestorAsync(
            InvestorDTO newInvestor,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<bool>();

            var response = await httpClient.PostAsJsonAsync("api/investor", newInvestor, cancellationToken);
            apiResponse.StatusCode = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage =
                    $"Failed to create investor. HTTP {response.StatusCode}. " +
                    await response.Content.ReadAsStringAsync(cancellationToken);               
                apiResponse.Completed = true;
                return apiResponse;
            }

            apiResponse.Data = response.IsSuccessStatusCode;
            apiResponse.Success = true;
            apiResponse.Completed = true;
            return apiResponse;
        }

        /// <summary>
        /// Creates a new investor.
        /// Corresponds to POST api/investor
        /// Returns ApiResponse with the created Investor.
        /// </summary>
        public async Task<ApiResponse<bool>> UpdateInvestorAsync(
            InvestorDTO investor,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<bool>();

            var response = await httpClient.PutAsJsonAsync($"api/investor/{investor.Id}", investor, cancellationToken);
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
        /// Deletes an investor by Id.
        /// Corresponds to DELETE api/investor/{id}
        /// Returns ApiResponse with boolean indicating success.
        /// </summary>
        public async Task<ApiResponse<bool>> DeleteInvestorAsync(
            int id, bool hardDelete = false,
            CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient(ApiClientName);
            var apiResponse = new ApiResponse<bool>();
            var url = hardDelete ? $"api/investor/{id}/hard-delete" : $"api/investor/{id}";
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
