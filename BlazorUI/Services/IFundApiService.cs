using Models.DTOs;
using System.Net;

namespace BlazorUI.Services
{
    public interface IFundApiService
    {
        Task<ApiResponse<List<FundDTO>>> GetFundsAsync(CancellationToken cancellationToken = default);
        Task<ApiResponse<FundDTO>> GetFundAsync(int id, CancellationToken cancellationToken = default);
        Task<ApiResponse<FundDTO>> CreateFundAsync(FundDTO newFund, CancellationToken cancellationToken = default);
        Task<ApiResponse<FundDTO>> UpdateFundAsync(FundDTO fund, CancellationToken cancellationToken = default);
        Task<ApiResponse<bool>> DeleteFundAsync(int id, bool hardDelete = false, CancellationToken cancellationToken = default);
        Task<ApiResponse<List<InvestorDTO>>> GetAllInvestorsByFund(int fundId, bool includeInvestments = false, CancellationToken cancellationToken = default);
    }
}
