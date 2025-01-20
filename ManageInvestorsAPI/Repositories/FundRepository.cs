using ManageInvestors.DataLayer;
using ManageInvestors.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageInvestors.Repositories
{
    public class FundRepository : IFundRepository
    {
        private readonly ApplicationDbContext _context;

        public FundRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fund>> GetAllFundsAsync(CancellationToken cancellationToken)
        {
            return await _context.Funds.AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Fund>> GetAllFundsByAdminAsync(CancellationToken cancellationToken)
        {
            return await _context.Funds.AsNoTracking().IgnoreQueryFilters().ToListAsync(cancellationToken);
        }

        public async Task<Fund> GetFundByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Funds.FindAsync(id, cancellationToken);
        }

        public async Task<List<Fund>> GetAllFundsByInvestorAsync(int investorId, CancellationToken cancellationToken)
        {
            return await _context.Investments.AsNoTracking()
                .Where(inv => inv.InvestorId == investorId)
                .Select(inv => inv.Fund)
                .ToListAsync(cancellationToken);
        }

        public async Task<Fund> CreateFundAsync(Fund fund, CancellationToken cancellationToken)
        {
            _context.Funds.Add(fund);
            await _context.SaveChangesAsync(cancellationToken);
            return fund;
        }
        public async Task<Fund> UpdateFundAsync(Fund fund, CancellationToken cancellationToken)
        {
            _context.Funds.Update(fund);
            await _context.SaveChangesAsync(cancellationToken);
            return fund;
        }

        public async Task<bool> DeleteFundAsync(int id, CancellationToken cancellationToken)
        {
            var fund = await _context.Funds.FindAsync(id , cancellationToken);
            if (fund != null)
            {
                _context.Funds.Remove(fund);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }


    }
}
