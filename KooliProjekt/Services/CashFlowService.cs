using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class CashFlowService : ICashFlowService
    {
        private readonly ApplicationDbContext _context;

        public CashFlowService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CashFlow>> GetAllAsync()
        {
            return await _context.CashFlows.ToListAsync();
        }

        public async Task<CashFlow?> GetByIdAsync(int id)
        {
            return await _context.CashFlows.FindAsync(id);
        }

        public async Task AddAsync(CashFlow cashFlow)
        {
            _context.CashFlows.Add(cashFlow);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CashFlow cashFlow)
        {
            _context.CashFlows.Update(cashFlow);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cashFlow = await _context.CashFlows.FindAsync(id);
            if (cashFlow != null)
            {
                _context.CashFlows.Remove(cashFlow);
                await _context.SaveChangesAsync();
            }
        }
    }
}

