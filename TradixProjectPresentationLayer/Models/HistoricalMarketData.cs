namespace TradixProjectPresentationLayer.Models
{
    public class HistoricalMarketData
    {
        public string Symbol { get; set; }
        public string DateTime { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public int Volume { get; set; }
        public decimal PercentageChange { get; set; }
    }
}
