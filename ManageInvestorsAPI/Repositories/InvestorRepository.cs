using ManageInvestors.DataLayer;
using ManageInvestors.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageInvestors.Repositories
{
    public class InvestorRepository : IInvestorRepository
    {
        private readonly ApplicationDbContext _context;

        public InvestorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Investor> GetInvestorAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Investors
                //.Include(i => i.Investments)
                .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<List<Investor>> GetAllInvestorsAsync(CancellationToken cancellationToken)
        {
            return await _context.Investors
                //.Include(i => i.Investments)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Investor>> GetAllInvestorsByAdminAsync(CancellationToken cancellationToken)
        {
            return await _context.Investors
                .Include(i => i.Investments)
                .IgnoreQueryFilters()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Investor>> GetAllInvestorsAndInvestmentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Investors
                .Include(i => i.Investments)
                .ThenInclude(inv => inv.Fund)
                .ToListAsync(cancellationToken);
        }

        public async Task<Investor> GetInvestorAndInvestmentsAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Investors
                .Where(i => i.Id == id)
                .Include(i => i.Investments)
                .ThenInclude(inv => inv.Fund)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Investor>> GetAllInvestorsByFundIdAsync(int fundId, CancellationToken cancellationToken)
        {
            return await _context.Investments
                .Where(inv => inv.FundId == fundId)
                .Select(inv => inv.Investor)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Investor>> GetInvestorsAndInvestmentsByFundIdAsync(int fundId, CancellationToken cancellationToken)
        {        
            return await _context.Investments
                .Where(inv => inv.FundId == fundId)
                .Include(i => i.Investor)    
                .Select(inv => inv.Investor)
                .ToListAsync(cancellationToken);
        }

        public async Task<Investor> CreateInvestorAsync(Investor investor, CancellationToken cancellationToken)
        {
            _context.Investors.Add(investor);
            await _context.SaveChangesAsync(cancellationToken);
            return investor;
        }
        public async Task<Investor> UpdateInvestorAsync(Investor investor, CancellationToken cancellationToken)
        {
            _context.Investors.Update(investor);
            await _context.SaveChangesAsync(cancellationToken);
            return investor;
        }

        public async Task<bool> DeleteInvestorAsync(int id, CancellationToken cancellationToken)
        {
            var investor = await _context.Investors.FindAsync(new object[] { id }, cancellationToken);
            if (investor != null)
            {
                _context.Investors.Remove(investor);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
