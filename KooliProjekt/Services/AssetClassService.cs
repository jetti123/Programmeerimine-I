using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class AssetClassService : IAssetClassService
    {
        private readonly ApplicationDbContext _context;

        public AssetClassService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AssetClass>> GetAllAsync()
        {
            return await _context.AssetClasses.ToListAsync();
        }

        public async Task<AssetClass?> GetByIdAsync(int id)
        {
            return await _context.AssetClasses.FindAsync(id);
        }

        public async Task AddAsync(AssetClass assetClass)
        {
            _context.AssetClasses.Add(assetClass);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AssetClass assetClass)
        {
            _context.AssetClasses.Update(assetClass);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var assetClass = await _context.AssetClasses.FindAsync(id);
            if (assetClass != null)
            {
                _context.AssetClasses.Remove(assetClass);
                await _context.SaveChangesAsync();
            }
        }
    }
}
