namespace FirstWebApp.Data
{
    public class RankingPremiumSmartphones
    {

        public int Id { get; set; }

        public int Position { get; set; }

        public int SmartphoneId { get; set; }
        public Smartphone Smartphone { get; set; }
    }
}