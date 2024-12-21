using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TradixProjectPresentationLayer.Models;

namespace TradixProjectPresentationLayer.Controllers
{
    public class HisseController : Controller
    {
        private readonly string _connectionString;

        public HisseController(IConfiguration configuration)
        {
            // appsettings.json'dan bağlantı dizesini alıyoruz
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            List<Hisse> exchangeRates = new List<Hisse>();  // List yerine Hisse tipi kullanıyoruz

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // ExchangeRates1 tablosundan veri çekiyoruz
                    string query = "SELECT Id, CurrencyCode, Unit, CurrencyName, ForexBuying, ForexSelling, CreatedDate FROM ExchangeRates1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Veriyi Hisse modeline ekliyoruz
                                exchangeRates.Add(new Hisse
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    CurrencyCode = reader["CurrencyCode"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    CurrencyName = reader["CurrencyName"].ToString(),
                                    ForexBuying = reader["ForexBuying"] != DBNull.Value ? Convert.ToDecimal(reader["ForexBuying"]) : 0,
                                    ForexSelling = reader["ForexSelling"] != DBNull.Value ? Convert.ToDecimal(reader["ForexSelling"]) : 0,
                                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                                });
                            }
                        }
                    }
                }

                // Verileri ViewBag ile View'e gönderiyoruz
                ViewBag.ExchangeRates1 = exchangeRates;
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajını ViewBag'e gönderiyoruz
                ViewBag.ErrorMessage = "Bir hata oluştu: " + ex.Message;
            }

            return View();
        }
    }
}
