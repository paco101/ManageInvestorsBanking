using ManageInvestors.Models;

namespace ManageInvestors.Repositories
{
    public interface IInvestorRepository
    {
        Task<Investor> GetInvestorAsync(int id, CancellationToken cancellationToken);
        Task<List<Investor>> GetAllInvestorsAsync(CancellationToken cancellationToken);
        Task<List<Investor>> GetAllInvestorsByAdminAsync(CancellationToken cancellationToken);
        Task<List<Investor>> GetAllInvestorsAndInvestmentsAsync(CancellationToken cancellationToken);
        Task<Investor> GetInvestorAndInvestmentsAsync(int id, CancellationToken cancellationToken);
        Task<List<Investor>> GetAllInvestorsByFundIdAsync(int fundId, CancellationToken cancellationToken);
        Task<List<Investor>> GetInvestorsAndInvestmentsByFundIdAsync(int fundId, CancellationToken cancellationToken);     
        Task<Investor> CreateInvestorAsync(Investor investor, CancellationToken cancellationToken);
        Task<Investor> UpdateInvestorAsync(Investor investor, CancellationToken cancellationToken);
        Task<bool> DeleteInvestorAsync(int id, CancellationToken cancellationToken);
    }
}
