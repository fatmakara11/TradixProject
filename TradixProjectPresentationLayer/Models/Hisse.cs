namespace TradixProjectPresentationLayer.Models
{
    public class Hisse
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string Unit { get; set; }
        public string CurrencyName { get; set; }
        public decimal ForexBuying { get; set; } // decimal tipi
        public decimal ForexSelling { get; set; } // decimal tipi
        public DateTime CreatedDate { get; set; }

    }
}
