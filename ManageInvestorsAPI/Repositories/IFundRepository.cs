using ManageInvestors.Models;

namespace ManageInvestors.Repositories
{
    public interface IFundRepository
    {
        Task<List<Fund>> GetAllFundsAsync(CancellationToken cancellationToken);
        Task<List<Fund>> GetAllFundsByAdminAsync(CancellationToken cancellationToken);
        Task<List<Fund>> GetAllFundsByInvestorAsync(int investorId, CancellationToken cancellationToken);
        Task<Fund> GetFundByIdAsync(int id, CancellationToken cancellationToken);
        Task<Fund> CreateFundAsync(Fund fund, CancellationToken cancellationToken);
        Task<Fund> UpdateFundAsync(Fund fund, CancellationToken cancellationToken);
        Task<bool> DeleteFundAsync(int id, CancellationToken cancellationToken);
    }
}
