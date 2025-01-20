using ManageInvestors.DataLayer;
using ManageInvestors.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManageInvestors.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly ApplicationDbContext _context;

        public InvestmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Investment> GetInvestmentAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Investments.AsNoTracking()
                .Include(i => i.Fund)
                .Include(i => i.Investor)
                .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<Investment> CreateInvestmentAsync(Investment investment, CancellationToken cancellationToken)
        {
            _context.Investments.Add(investment);          

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");

                if (ex.InnerException is SqlException sqlEx)
                {
                    Console.WriteLine($"SQL Error: {sqlEx.Message}");
                    // Inspect query if available
                }

                throw; // Re-throw the exception if needed
            }
            return investment;
        }

        public async Task<Investment> UpdateInvestmentAsync(Investment investment, CancellationToken cancellationToken)
        {
            _context.Investments.Update(investment);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");

                if (ex.InnerException is SqlException sqlEx)
                {
                    Console.WriteLine($"SQL Error: {sqlEx.Message}");
                    // Inspect query if available
                }

                throw; // Re-throw the exception if needed
            }
            return investment;
        }

        public async Task<bool> DeleteInvestmentAsync(int id, CancellationToken cancellationToken)
        {
            var investment = await _context.Investments.FindAsync(new object[] { id }, cancellationToken);
            if (investment != null)
            {
                _context.Investments.Remove(investment);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
