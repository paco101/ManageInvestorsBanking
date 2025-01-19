using ManageInvestors.Models;
using ManageInvestors.Repositories;

namespace ManageInvestors.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;

        public InvestmentService(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<Investment> GetInvestmentAsync(int id, CancellationToken cancellationToken)
        {
            return await _investmentRepository.GetInvestmentAsync(id, cancellationToken);
        }

        public async Task<Investment> CreateInvestmentAsync(Investment investment, CancellationToken cancellationToken)
        {
            // If we need any extra validations or cross-checking between repositories, do it here
            investment.TransactionDateTime = DateTime.UtcNow;
            return await _investmentRepository.CreateInvestmentAsync(investment, cancellationToken);
        }

        public async Task<Investment> UpdateInvestmentAsync(Investment investment, CancellationToken cancellationToken)
        {
            // e.g., validate investor fields, check duplicates, etc.
            return await _investmentRepository.UpdateInvestmentAsync(investment, cancellationToken);
        }

        public async Task<bool> DeleteInvestmentAsync(int id, CancellationToken cancellationToken)
        {
            return await _investmentRepository.DeleteInvestmentAsync(id, cancellationToken);
        }
    }
}
