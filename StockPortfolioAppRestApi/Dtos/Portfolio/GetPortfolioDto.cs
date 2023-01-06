namespace StockPortfolioApp.Dtos.Portfolio
{
    public class GetPortfolioDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String? Name { get; set; }
        public String? Description { get; set; }
    }
}
