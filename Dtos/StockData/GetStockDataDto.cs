namespace StockPortfolioApp.Dtos.StockData
{
    public class GetStockDataDto
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public Decimal Value { get; set; }
        public int Volume { get; set; }
        public DateTime RegisterTimestamp { get; set; }
    }
}
