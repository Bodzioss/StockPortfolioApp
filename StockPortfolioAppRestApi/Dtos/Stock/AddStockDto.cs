namespace StockPortfolioApp.Dtos.Stock
{
    public class AddStockDto
    {
        public String? Name { get; set; }
        public String? Ticker { get; set; }
        public int StockExchangeId { get; set; }
    }
}
