using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IMonthlyDataService
    {
        Task<List<MonthlyData>> GetAllWithAssetAsync();
        Task<MonthlyData?> GetByIdWithAssetAsync(int id);
        Task<MonthlyData?> GetByIdAsync(int id);
        Task AddAsync(MonthlyData monthlyData);
        Task UpdateAsync(MonthlyData monthlyData);
        Task DeleteAsync(int id);
    }
}

