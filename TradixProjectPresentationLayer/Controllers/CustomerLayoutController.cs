using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using TradixProjectPresentationLayer.Models;


namespace TradixProjectPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        private readonly string _connectionString = "Server=FATMA\\SQLEXPRESS;Database=TradixProjectDb;Integrated Security=True;TrustServerCertificate=True;";

        public IActionResult Index()
        {
            List<dynamic> exchangeRates = new List<dynamic>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query  = "SELECT Id, CurrencyCode, Unit, CurrencyName,ForexBuying,ForexSelling, CreatedDate FROM ExchangeRates";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                exchangeRates.Add(new
                                {
                                    Id = reader["Id"],
                                    CurrencyCode = reader["CurrencyCode"],
                                    Unit = reader["Unit"],
                                    CurrencyName = reader["CurrencyName"],
                                    ForexBuying = reader["ForexBuying"],
                                    ForexSelling = reader["ForexSelling"],
                                    CreatedDate = reader["CreatedDate"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Bir hata oluştu: " + ex.Message;
            }

            ViewBag.ExchangeRates = exchangeRates;
            return View();
        }
    }

}
