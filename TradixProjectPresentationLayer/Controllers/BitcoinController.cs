﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using TradixProjectPresentationLayer.Models;

public class BitcoinController : Controller
{
    private readonly string _connectionString = "Server=FATMA\\SQLEXPRESS;Database=ExchangeRates;Trusted_Connection=True;TrustServerCertificate=True;";

    public IActionResult Index()
    {
        List<BitcoinPara> bitcoinParalar = new List<BitcoinPara>();

        using (var connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM bitcoin_verileri WHERE Durum = 1";  // Veritabanı tablonuzun adını kontrol edin

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    bitcoinParalar.Add(new BitcoinPara
                    {
                        Id = reader.GetInt32(0),
                        BitcoinAdi = reader.GetString(1),
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

        return View(bitcoinParalar);
    }
}