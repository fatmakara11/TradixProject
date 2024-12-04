/*using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace TradixProjectPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TradixProjectPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _connectionString;

        public CustomerLayoutController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("Connection string not found.");
        }

        public async Task<IActionResult> Index()
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";

            try
            {
                var response = await _httpClient.GetStringAsync(url);
                XDocument xmlDoc = XDocument.Parse(response);

                var currencyData = xmlDoc.Descendants("Currency")
                    .Select(c => new
                    {
                        CurrencyCode = c.Attribute("CurrencyCode")?.Value,
                        Unit = c.Element("Unit")?.Value,
                        CurrencyName = c.Element("Isim")?.Value,
                        ForexBuying = c.Element("ForexBuying")?.Value,
                        ForexSelling = c.Element("ForexSelling")?.Value
                    }).ToList();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    foreach (var currency in currencyData)
                    {
                        string query = @"
                        INSERT INTO ExchangeRates (CurrencyCode, Unit, CurrencyName, ForexBuying, ForexSelling, CreatedDate)
                        VALUES (@CurrencyCode, @Unit, @CurrencyName, @ForexBuying, @ForexSelling, GETDATE());";

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CurrencyCode", currency.CurrencyCode ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Unit", currency.Unit ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@CurrencyName", currency.CurrencyName ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@ForexBuying", currency.ForexBuying ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@ForexSelling", currency.ForexSelling ?? (object)DBNull.Value);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                ViewBag.Message = "Döviz kurları başarıyla çekildi ve kaydedildi.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Bir hata oluştu: " + ex.Message;
            }

            return View();
        }
    }
}
