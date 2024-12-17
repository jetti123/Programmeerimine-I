namespace KooliProjekt.Data
{
    public static class SeedData
    {
        public static void Generate(ApplicationDbContext context)
        {
            // Kontrolli, kas andmebaasis on juba andmeid
            if (context.AssetClasses.Any() || context.Assets.Any() || context.CashFlows.Any() || context.MonthlyData.Any())
            {
                return; // Kui andmed on olemas, välju meetodist
            }

            // Lisa andmed AssetClasses tabelisse
            context.AssetClasses.AddRange(
                new AssetClass { Name = "Real Estate" },
                new AssetClass { Name = "Stocks" },
                new AssetClass { Name = "Bonds" },
                new AssetClass { Name = "Mutual Funds" },
                new AssetClass { Name = "Gold" },
                new AssetClass { Name = "Crypto" },
                new AssetClass { Name = "Commodities" },
                new AssetClass { Name = "Savings" },
                new AssetClass { Name = "Private Equity" },
                new AssetClass { Name = "Cash" }
            );

            // Lisa andmed Assets tabelisse
            context.Assets.AddRange(
                new Asset { Name = "Office Building", AssetClassId = 1 },
                new Asset { Name = "Tech Stocks", AssetClassId = 2 },
                new Asset { Name = "Government Bond", AssetClassId = 3 },
                new Asset { Name = "S&P 500 Fund", AssetClassId = 4 },
                new Asset { Name = "Gold Reserve", AssetClassId = 5 },
                new Asset { Name = "Bitcoin", AssetClassId = 6 },
                new Asset { Name = "Oil Contracts", AssetClassId = 7 },
                new Asset { Name = "Emergency Fund", AssetClassId = 8 },
                new Asset { Name = "Venture Fund", AssetClassId = 9 },
                new Asset { Name = "Cash Reserves", AssetClassId = 10 }
            );

            // Lisa andmed CashFlow tabelisse
            context.CashFlows.AddRange(
                new CashFlow { Date = DateTime.Now, Amount = 5000, Description = "Initial Investment" },
                new CashFlow { Date = DateTime.Now, Amount = 3000, Description = "Rental Income" },
                new CashFlow { Date = DateTime.Now, Amount = -2000, Description = "Stock Purchase" },
                new CashFlow { Date = DateTime.Now, Amount = 4000, Description = "Bond Income" },
                new CashFlow { Date = DateTime.Now, Amount = -1000, Description = "Crypto Investment" }
            );

            // Salvesta andmed andmebaasi
            context.SaveChanges();
        }
    }
}
