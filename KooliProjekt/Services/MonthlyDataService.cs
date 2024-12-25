using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class MonthlyDataService : IMonthlyDataService
    {
        private readonly ApplicationDbContext _context;

        public MonthlyDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MonthlyData>> GetAllWithAssetAsync()
        {
            // Tagastab kõik MonthlyData kirjed koos seotud Asset-iga
            return await _context.MonthlyData.Include(m => m.Asset).ToListAsync();
        }

        public async Task<MonthlyData?> GetByIdWithAssetAsync(int id)
        {
            // Tagastab konkreetse MonthlyData kirje koos seotud Asset-iga
            return await _context.MonthlyData.Include(m => m.Asset).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<MonthlyData>> GetAllAsync()
        {
            // Tagastab kõik MonthlyData kirjed
            return await _context.MonthlyData.ToListAsync();
        }

        public async Task<MonthlyData?> GetByIdAsync(int id)
        {
            // Otsib MonthlyData kirjet ID alusel
            return await _context.MonthlyData.FindAsync(id);
        }

        public async Task AddAsync(MonthlyData monthlyData)
        {
            // Lisab uue MonthlyData kirje
            _context.MonthlyData.Add(monthlyData);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MonthlyData monthlyData)
        {
            // Uuendab olemasolevat MonthlyData kirjet
            _context.MonthlyData.Update(monthlyData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Kustutab MonthlyData kirje ID alusel
            var monthlyData = await _context.MonthlyData.FindAsync(id);
            if (monthlyData != null)
            {
                _context.MonthlyData.Remove(monthlyData);
                await _context.SaveChangesAsync();
            }
        }
    }
}


