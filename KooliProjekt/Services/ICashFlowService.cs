using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface ICashFlowService
    {
        Task<List<CashFlow>> GetAllAsync();
        Task<CashFlow?> GetByIdAsync(int id);
        Task AddAsync(CashFlow cashFlow);
        Task UpdateAsync(CashFlow cashFlow);
        Task DeleteAsync(int id);
    }
}
