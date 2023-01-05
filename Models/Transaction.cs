using System.ComponentModel.DataAnnotations;

namespace StockPortfolioApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int StockId { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Value { get; set; }
        public int Amount { get; set; }
        public Portfolio? Portfolio { get; set; }
        public Stock? Stock { get; set; }
    }
}
