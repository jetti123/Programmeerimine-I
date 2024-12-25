using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IAssetClassService
    {
        Task<List<AssetClass>> GetAllAsync();
        Task<AssetClass?> GetByIdAsync(int id);
        Task AddAsync(AssetClass assetClass);
        Task UpdateAsync(AssetClass assetClass);
        Task DeleteAsync(int id);
    }
}
