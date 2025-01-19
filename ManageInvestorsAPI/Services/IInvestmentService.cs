using ManageInvestors.Models;
using Models.DTOs;

namespace ManageInvestors.Services
{
    public interface IInvestmentService
    {
        Task<InvestmentDTO> GetInvestmentAsync(int id, CancellationToken cancellationToken);
        Task<InvestmentDTO> CreateInvestmentAsync(InvestmentDTO investment, CancellationToken cancellationToken);
        Task<InvestmentDTO> UpdateInvestmentAsync(InvestmentDTO investment, CancellationToken cancellationToken);
        Task<bool> DeleteInvestmentAsync(int id, CancellationToken cancellationToken);
    }
}
