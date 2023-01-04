namespace StockPortfolioApp.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private static List<Transaction> transactions = new List<Transaction> {
            new Transaction
            {
                Id = 1,
                StockId = 1,
                PortfolioId = 1,
                Value = 1,
                Amount = 1
            }
        };

        public List<Transaction> AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
            return transactions;
        }

        public List<Transaction> DeleteTransaction(int id)
        {
            var transaction = transactions.Find(x => x.Id == id);

            if (transaction is null)
                return null;

            transactions.Remove(transaction);
            return transactions;
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }

        public Transaction GetSingleTransaction(int id)
        {
            var transaction = transactions.Find(x => x.Id == id);
            return transaction;
        }

        public List<Transaction> UpdateTransaction(int id, Transaction request)
        {
            var transaction = transactions.Find(x => x.Id == id);

            if (transaction is null)
                return null;

            transaction.StockId = request.StockId;
            transaction.PortfolioId = request.PortfolioId;
            transaction.Value = request.Value;
            transaction.Amount = request.Amount;

            return transactions;
        }
    }
}
