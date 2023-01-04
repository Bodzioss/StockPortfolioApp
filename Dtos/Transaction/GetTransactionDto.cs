namespace StockPortfolioApp.Dtos.Transaction
{
    public class GetTransactionDto
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int StockId { get; set; }
        public Decimal Value { get; set; }
        public int Amount { get; set; }
    }
}
