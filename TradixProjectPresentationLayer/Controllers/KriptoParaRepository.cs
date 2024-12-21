// KriptoParaRepository.cs
using System.Collections.Generic;
using System.Data.SqlClient;
using TradixProject.DataAccessLayer.Repositories;
using TradixProjectPresentationLayer.Models;

public class KriptoParaRepository : IKriptoParaRepository
{
    private readonly string _connectionString = "Server=FATMA\\SQLEXPRESS;Database=ExchangeRates;Trusted_Connection=True;TrustServerCertificate=True;";

    public List<KriptoPara> GetAllKriptoParalar()
    {
        List<KriptoPara> kriptoParalar = new List<KriptoPara>();

        using (var connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM kripto_paralar WHERE Durum = 1";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    kriptoParalar.Add(new KriptoPara
                    {
                        Id = reader.GetInt32(0),
                        KriptoAdi = reader.GetString(1),
                        AlisFiyati = reader.GetDecimal(2),
                        SatisFiyati = reader.GetDecimal(3),
                        PiyasaDegeri = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4),
                        GunlukHacim = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5),
                        DegisimYuzdesi = reader.IsDBNull(6) ? (decimal?)null : reader.GetDecimal(6),
                        Durum = reader.GetBoolean(7)
                    });
                }
            }
        }

        return kriptoParalar;
    }
}
