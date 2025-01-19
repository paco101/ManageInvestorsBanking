using ManageInvestors.Models;
using ManageInvestors.Repositories;

namespace ManageInvestors.Services
{
    public class FundService : IFundService
    {
        private readonly IFundRepository _fundRepository;

        public FundService(IFundRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public async Task<List<Fund>> GetAllFundsAsync(CancellationToken cancellationToken)
        {
            return await _fundRepository.GetAllFundsAsync(cancellationToken);
        }

        public async Task<Fund> GetFundByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _fundRepository.GetFundByIdAsync(id, cancellationToken);
        }

        public async Task<Fund> CreateFundAsync(Fund fund, CancellationToken cancellationToken)
        {
            // e.g., check if fund name is unique, etc.
            return await _fundRepository.CreateFundAsync(fund, cancellationToken);
        }

        public async Task<Fund> UpdateFundAsync(Fund investor, CancellationToken cancellationToken)
        {
            // e.g., validate fund fields, check duplicates, etc.
            return await _fundRepository.UpdateFundAsync(investor, cancellationToken);
        }

        public async Task<bool> DeleteFundAsync(int id, CancellationToken cancellationToken)
        {
            return await _fundRepository.DeleteFundAsync(id, cancellationToken);
        }
    }
}
