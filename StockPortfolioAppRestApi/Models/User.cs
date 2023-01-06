using System.Reflection.Metadata.Ecma335;

namespace StockPortfolioApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public String? Username { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public List<Portfolio>? Portfolios { get; set; }
    }
}
