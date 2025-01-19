using ManageInvestors.Models;
using Models.DTOs;

namespace ManageInvestors.Services
{
    public interface IInvestorService
    {
        Task<List<InvestorDTO>> GetAllInvestorsAsync(CancellationToken cancellationToken);
        Task<InvestorDTO> GetInvestorAsync(int id, CancellationToken cancellationToken);
        Task<List<InvestorDTO>> GetAllInvestorsByAdminAsync(CancellationToken cancellationToken);
        Task<List<InvestorDTO>> GetAllInvestorsAndInvestmentsAsync(CancellationToken cancellationToken);
        Task<InvestorDTO> GetInvestorAndInvestmentsAsync(int id, CancellationToken cancellationToken);
        Task<List<InvestorDTO>> GetAllInvestorsByFundIdAsync(int fundId, CancellationToken cancellationToken);
        Task<List<InvestorDTO>> GetInvestorsAndInvestmentsByFundIdAsync(int fundId, CancellationToken cancellationToken);
        Task<Investor> CreateInvestorAsync(Investor investor, CancellationToken cancellationToken);
        Task<InvestorDTO> UpdateInvestorAsync(InvestorDTO investor, CancellationToken cancellationToken);
        Task<bool> DeleteInvestorAsync(int id, CancellationToken cancellationToken);
    }
}
