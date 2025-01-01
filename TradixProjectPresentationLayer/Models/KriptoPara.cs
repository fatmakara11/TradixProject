namespace TradixProjectPresentationLayer.Models
{
    public class KriptoPara
    {
        public int Id { get; set; }
        public string KriptoAdi { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public decimal? PiyasaDegeri { get; set; }
        public decimal? GunlukHacim { get; set; }
        public decimal? DegisimYuzdesi { get; set; }
        public bool Durum { get; set; }
    }

    // SINGLE RESPONSIBILITY PRINCIPLE (SRP): 
    // Bu model yalnızca veritabanındaki kripto para verilerini temsil eder.
    // İş mantığı, controller ya da service katmanlarında yer almalıdır.
}
