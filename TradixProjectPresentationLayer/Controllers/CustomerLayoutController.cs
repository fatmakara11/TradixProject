using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TradixProjectPresentationLayer.Models;
using System.Collections.Generic;

namespace TradixProjectPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            // Verilerinizi burada oluşturun (bu örnekte sabit veri kullanıyoruz)
            var historicalMarketDataList = new List<HistoricalMarketData>
        {
            new HistoricalMarketData
            {
                Symbol = "XAU",
                DateTime = "2024-12-01",
                OpenPrice = 2250.00m,
                ClosePrice = 2300.00m,
                HighPrice = 2330.00m,
                LowPrice = 2200.00m,
                Volume = 5900000,
                PercentageChange = 2.22m
            },
            new HistoricalMarketData
            {
                Symbol = "XAU_GR",
                DateTime = "2024-12-01",
                OpenPrice = 1570.00m,
                ClosePrice = 1620.00m,
                HighPrice = 1640.00m,
                LowPrice = 1540.00m,
                Volume = 2800000,
                PercentageChange = 3.17m
            },
            new HistoricalMarketData
            {
                Symbol = "USD",
                DateTime = "2024-12-01",
                OpenPrice = 1.22m,
                ClosePrice = 1.25m,
                HighPrice = 1.26m,
                LowPrice = 1.21m,
                Volume = 10450000,
                PercentageChange = 2.46m
            },
            new HistoricalMarketData
            {
                Symbol = "EUR",
                DateTime = "2024-12-01",
                OpenPrice = 1.37m,
                ClosePrice = 1.38m,
                HighPrice = 1.40m,
                LowPrice = 1.35m,
                Volume = 5900000,
                PercentageChange = 0.73m
            },
            new HistoricalMarketData
            {
                Symbol = "BTC",
                DateTime = "2024-12-01",
                OpenPrice = 57000.00m,
                ClosePrice = 59000.00m,
                HighPrice = 60000.00m,
                LowPrice = 56000.00m,
                Volume = 106000000,
                PercentageChange = 3.51m
            },
            new HistoricalMarketData
            {
                Symbol = "ETH",
                DateTime = "2024-12-01",
                OpenPrice = 3900.00m,
                ClosePrice = 4000.00m,
                HighPrice = 4100.00m,
                LowPrice = 3800.00m,
                Volume = 31000000,
                PercentageChange = 2.56m
            }
        };

            // Veriyi view'a gönder
            return View(historicalMarketDataList);
        }
    }
}
