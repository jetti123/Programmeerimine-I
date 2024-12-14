using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AssetClass> AssetClasses { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<MonthlyData> MonthlyData { get; set; }
        public DbSet<CashFlow> CashFlows { get; set; }


    }
}