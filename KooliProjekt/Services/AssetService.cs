using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class AssetService : IAssetService
    {
        private readonly ApplicationDbContext _context;

        public AssetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Asset>> GetAllAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset?> GetByIdAsync(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task AddAsync(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Asset asset)
        {
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset != null)
            {
                _context.Assets.Remove(asset);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Asset>> GetAllWithAssetClassAsync()
        {
            return await _context.Assets.Include(a => a.AssetClass).ToListAsync();
        }

        public async Task<Asset?> GetByIdWithAssetClassAsync(int id)
        {
            return await _context.Assets.Include(a => a.AssetClass).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<Asset>> ListAsync(AssetSearch search)
        {
            var query = _context.Assets.AsQueryable();

            // Otsing nime järgi
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(a => a.Name.Contains(search.SearchTerm.Trim()));
            }

            // Filtreerimine varaklassi järgi
            if (search.AssetClassId.HasValue)
            {
                query = query.Where(a => a.AssetClassId == search.AssetClassId.Value);
            }

            return await query.Include(a => a.AssetClass).ToListAsync();
        }

    }
}

