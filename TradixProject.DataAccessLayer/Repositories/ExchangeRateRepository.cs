using Intuit.Ipp.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TradixProject.DataAccessLayer.Concrete;
using TradixProject.DtoLayer.ExchangeRateDtos;

namespace TradixProject.DataAccessLayer.Repositories
{
    public class ExchangeRateRepository
    {
        private readonly string _connectionString;

        // Connection string, genellikle appsettings.json'dan alınır
        public ExchangeRateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ExchangeRates verilerini çekme
        public List<ResualtExhangeRateDto> GetExchangeRates()
        {
            var exchangeRates = new List<ResualtExhangeRateDto>();

            // SQL bağlantısını açıyoruz
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // SQL sorgusunu tanımlıyoruz
                string query = "SELECT * FROM ExchangeRates"; // Veritabanındaki doğru tabloyu ve alanları kullanın

                using (var command = new SqlCommand(query, connection))
                {
                    // Sorguyu çalıştırıyoruz
                    using (var reader = command.ExecuteReader())
                    {
                        // Veriyi okuyup DTO'ya dönüştürüyoruz
                        while (reader.Read())
                        {
                            var exchangeRate = new ResualtExhangeRateDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CurrencyCode = reader.GetString(reader.GetOrdinal("CurrencyCode")),
                                Unit = reader.GetString(reader.GetOrdinal("Unit")),
                                CurrencyName = reader.GetString(reader.GetOrdinal("CurrencyName")),
                                ForexBuying = reader.IsDBNull(reader.GetOrdinal("ForexBuying")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ForexBuying")),
                                ForexSelling = reader.IsDBNull(reader.GetOrdinal("ForexSelling")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ForexSelling")),
                                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))
                            };

                            exchangeRates.Add(exchangeRate);
                        }
                    }
                }
            }

            return exchangeRates;
        }
    }

}
