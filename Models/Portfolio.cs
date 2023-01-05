using System.Diagnostics;

namespace StockPortfolioApp.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String? Name { get; set; }
        public String? Description { get; set; }
        public User? User { get; set; }
        public List<PortfolioComponent>? PortfolioComponents { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
}
