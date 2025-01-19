using ManageInvestors.Models;

namespace ManageInvestors.Services
{
    public interface IFundService
    {
        Task<List<Fund>> GetAllFundsAsync(CancellationToken cancellationToken);
        Task<Fund> GetFundByIdAsync(int id, CancellationToken cancellationToken);
        Task<Fund> CreateFundAsync(Fund fund, CancellationToken cancellationToken);
        Task<Fund> UpdateFundAsync(Fund investor, CancellationToken cancellationToken);
        Task<bool> DeleteFundAsync(int id, CancellationToken cancellationToken);
    }
}
