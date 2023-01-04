namespace StockPortfolioApp.Dtos.Stock
{
    public class GetStockDto
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Ticker { get; set; }
        public int StockExchangeId { get; set; }
    }
}
