
using Intuit.Ipp.Data;
using Microsoft.EntityFrameworkCore;
using TradixProject.DataAccessLayer.Repositories;

namespace TradixProject.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<ExchangeRate> ExchangeRate
        { get; set; }  // ExchangeRate tablosu için DbSet

        // Diğer DbSet'ler burada yer alabilir
        public DbSet<HistoricalMarketData> HistoricalMarketData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=FATMA\\SQLEXPRESS;initial catalog=ExchangeRates;integrated Security=true;TrustServerCertificate=True");
            }
        }
    }
}
