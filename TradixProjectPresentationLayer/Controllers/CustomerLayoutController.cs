using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TradixProjectPresentationLayer.Models;

namespace TradixProjectPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            // ****************** DESIGN PATTERN: TEMPLATE METHOD ******************
            // BU METOT, BELİRLİ BİR İŞ AKIŞINI (HISTORICAL DATA'NIN OLUŞTURULMASI VE GÖRÜNÜME GÖNDERİLMESİ) TEKRARLANABİLİR ŞEKİLDE TANIMLAR. 
            // ŞABLON METOD, ANA İŞLEYİŞİ BELİRLEYEN VE İŞİN ALT DETAYLARINI ALT SINIFLARA BIRAKAN BİR DESENDİR.
            // BU ÖRNEKTE, VERİ OLUŞTURMA (SABİT VERİ) KODU KONTROL ALTINDADIR VE GÖRÜNÜME GÖNDERİLMESİ ANA METODUN KONTROLÜNDEDİR.

            // Verilerinizi burada oluşturun (bu örnekte sabit veri kullanıyoruz)
            var historicalMarketDataList = new List<HistoricalMarketData>
            {
                new HistoricalMarketData
                {
                    Symbol = "XAU",
                    DateTime = "2024-12-31", // Güncellenmiş tarih
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
                    DateTime = "2024-12-31", // Güncellenmiş tarih
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
                    DateTime = "2024-12-31", // Güncellenmiş tarih
                    OpenPrice = 35.35m, // 1 USD = 35,35 TRY
                    ClosePrice = 35.35m, // 1 USD = 35,35 TRY
                    HighPrice = 35.50m,  // Güncel tahmini yüksek fiyat
                    LowPrice = 35.00m,   // Güncel tahmini düşük fiyat
                    Volume = 10450000,
                    PercentageChange = 2.46m
                },
                new HistoricalMarketData
                {
                    Symbol = "EUR",
                    DateTime = "2024-12-31", // Güncellenmiş tarih
                    OpenPrice = 37.85m, // 1 EUR = 37,85 TRY
                    ClosePrice = 37.85m, // 1 EUR = 37,85 TRY
                    HighPrice = 38.00m,  // Güncel tahmini yüksek fiyat
                    LowPrice = 37.50m,   // Güncel tahmini düşük fiyat
                    Volume = 5900000,
                    PercentageChange = 0.73m
                },
                new HistoricalMarketData
                {
                    Symbol = "BTC",
                    DateTime = "2024-12-31", // Güncellenmiş tarih
                    OpenPrice = 1500000.00m, // 1 BTC = 1.500.000 TRY
                    ClosePrice = 1500000.00m, // 1 BTC = 1.500.000 TRY
                    HighPrice = 1550000.00m, // Güncel tahmini yüksek fiyat
                    LowPrice = 1450000.00m,  // Güncel tahmini düşük fiyat
                    Volume = 106000000,
                    PercentageChange = 3.51m
                },
                new HistoricalMarketData
                {
                    Symbol = "ETH",
                    DateTime = "2024-12-31", // Güncellenmiş tarih
                    OpenPrice = 80000.00m, // 1 ETH = 80.000 TRY
                    ClosePrice = 80000.00m, // 1 ETH = 80.000 TRY
                    HighPrice = 82000.00m,  // Güncel tahmini yüksek fiyat
                    LowPrice = 78000.00m,   // Güncel tahmini düşük fiyat
                    Volume = 31000000,
                    PercentageChange = 2.56m
                }
            };

            // ****************** DESIGN PATTERN: MVC (MODEL-VIEW-CONTROLLER) ******************
            // BU DESEN, VERİ İŞLEME (MODEL), KONTROL (CONTROLLER) VE KULLANICI ARAYÜZÜNÜ (VIEW) AYIRARAK PROJENİN MODÜLER VE TEST EDİLEBİLİR OLMASINI SAĞLAR.
            // BURADA CONTROLLER, VERİYİ OLUŞTURUP VIEW'A AKTARARAK MVC DESENİNİN "CONTROLLER" ROLÜNÜ OYNAR.

            // Veriyi view'a gönder
            return View(historicalMarketDataList);
        }
    }
}
