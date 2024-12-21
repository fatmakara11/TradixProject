using Microsoft.AspNetCore.Mvc;
using TradixProjectPresentationLayer.Models;

namespace TradixProjectPresentationLayer.Controllers
{
    public class MarketDataController : Controller
    {
        // Bu metot verileri simulate ediyor. Gerçek bir veritabanı ya da API kullanabilirsiniz.
        public List<HistoricalMarketData> GetMarketData()
        {
            return new List<HistoricalMarketData>
        {
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-01-01", ClosePrice = 1800.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-02-01", ClosePrice = 1790.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-03-01", ClosePrice = 1850.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-04-01", ClosePrice = 1900.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-05-01", ClosePrice = 1950.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-06-01", ClosePrice = 2000.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-07-01", ClosePrice = 2050.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-08-01", ClosePrice = 2100.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-09-01", ClosePrice = 2150.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-10-01", ClosePrice = 2200.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-11-01", ClosePrice = 2250.00m },
            new HistoricalMarketData { Symbol = "XAU", DateTime = "2024-12-01", ClosePrice = 2300.00m },
        };
        }

        // View'a veri aktarma
        public IActionResult Index()
        {
            var marketData = GetMarketData();
            return View(marketData);
        }
    }
}
