namespace TradixProjectPresentationLayer.Models
{
    public class MonthlyMarketData
    {
        public string Symbol { get; set; }
        public string Month { get; set; }  // Örneğin, Ocak, Şubat...
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public int Volume { get; set; }
        public decimal PercentageChange { get; set; }
    }
}
