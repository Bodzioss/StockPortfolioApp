
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public DbSet<Portfolio> Portfolios => Set<Portfolio>();
        public DbSet<PortfolioComponent> PortfolioComponents => Set<PortfolioComponent>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<StockData> StockDatas => Set<StockData>();
        public DbSet<StockExchange> StockExchange => Set<StockExchange>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<User> Users => Set<User>();
    }
}
