namespace StockPortfolioApp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Ticker { get; set; }
        public int MarketId { get; set; }

    }
}
