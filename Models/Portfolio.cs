using System.Diagnostics;

namespace StockPortfolioApp.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
