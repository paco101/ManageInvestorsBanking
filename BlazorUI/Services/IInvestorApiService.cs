using Models.DTOs;
using System.Net;

namespace BlazorUI.Services
{
    public interface IInvestorApiService
    {
        Task<ApiResponse<List<InvestorDTO>>> GetInvestorsAsync(CancellationToken cancellationToken = default);
        Task<ApiResponse<List<InvestorDTO>>> GetInvestorsAndInvestmentsAsync(CancellationToken cancellationToken = default);
        Task<ApiResponse<InvestorDTO>> GetInvestorAsync(int id, CancellationToken cancellationToken = default);
        Task<ApiResponse<InvestorDTO>> GetInvestorAndInvestmentsAsync(int id, CancellationToken cancellationToken = default);
        Task<ApiResponse<bool>> CreateInvestorAsync(InvestorDTO newInvestor, CancellationToken cancellationToken = default);
        Task<ApiResponse<bool>> UpdateInvestorAsync(InvestorDTO investor, CancellationToken cancellationToken = default);
        Task<ApiResponse<bool>> DeleteInvestorAsync(int id, bool hardDelete = false, CancellationToken cancellationToken = default);
    }
}
