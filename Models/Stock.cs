namespace StockPortfolioApp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Ticker { get; set; }
        public int StockExchangeId { get; set; }

    }
}
