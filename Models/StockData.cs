namespace StockPortfolioApp.Models
{
    public class StockData
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public Decimal Value { get; set; }
        public int Volume { get; set; }
        public DateTime RegisterTimestamp { get; set; }
    }
}
