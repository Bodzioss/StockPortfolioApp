namespace StockPortfolioApp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Ticker { get; set; }
        public int StockExchangeId { get; set; }
        public StockExchange? StockExchange { get; set; }
        public List<StockData>? StockDatas { get; set; }
        public List<PortfolioComponent>? PortfolioComponents { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
}
