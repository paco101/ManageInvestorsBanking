using ManageInvestors.Models;
using Models.DTOs;
using System.Net;

namespace BlazorUI.Services
{
    public interface IInvestmentApiService
    {
        Task<ApiResponse<List<Investment>>> GetInvestmentsAsync(CancellationToken cancellationToken = default);
        Task<ApiResponse<Investment>> GetInvestmentAsync(int id, CancellationToken cancellationToken = default);
        Task<ApiResponse<bool>> CreateInvestmentAsync(InvestmentDTO newInvestment, CancellationToken cancellationToken = default);
        Task<ApiResponse<bool>> UpdateInvestmentAsync(InvestmentDTO investment, CancellationToken cancellationToken = default);
        Task<ApiResponse<bool>> DeleteInvestmentAsync(int id, bool hardDelete = false, CancellationToken cancellationToken = default);
    }
}
