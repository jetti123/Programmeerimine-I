using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAllAsync();
        Task<Asset?> GetByIdAsync(int id);
        Task AddAsync(Asset asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(int id);
        Task<List<Asset>> GetAllWithAssetClassAsync();
        Task<Asset?> GetByIdWithAssetClassAsync(int id);
        Task<List<Asset>> ListAsync(AssetSearch search);


    }
}

