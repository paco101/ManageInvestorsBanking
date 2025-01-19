using ManageInvestors.Models;

namespace ManageInvestors.Repositories
{
    public interface IInvestmentRepository
    {
        Task<Investment> GetInvestmentAsync(int id, CancellationToken cancellationToken);
        Task<Investment> CreateInvestmentAsync(Investment investment, CancellationToken cancellationToken);
        Task<Investment> UpdateInvestmentAsync(Investment investment, CancellationToken cancellationToken);
        Task<bool> DeleteInvestmentAsync(int id, CancellationToken cancellationToken);
    }
}
