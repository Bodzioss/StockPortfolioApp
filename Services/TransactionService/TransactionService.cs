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

        public async Task<ServiceResponse<List<Transaction>>> AddTransaction(Transaction transaction)
        {
            var serviceResponse = new ServiceResponse<List<Transaction>>();
            transactions.Add(transaction);
            serviceResponse.Data = transactions;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Transaction>>> DeleteTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<List<Transaction>>();
            var transaction = transactions.Find(x => x.Id == id);

            if (transaction is null)
                return null;

            transactions.Remove(transaction);
            serviceResponse.Data = transactions;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Transaction>>> GetAllTransactions()
        {
            var serviceResponse = new ServiceResponse<List<Transaction>>();
            serviceResponse.Data = transactions;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Transaction>> GetSingleTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<Transaction>();
            var transaction = transactions.Find(x => x.Id == id);
            serviceResponse.Data = transaction;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Transaction>>> UpdateTransaction(int id, Transaction request)
        {
            var serviceResponse = new ServiceResponse<List<Transaction>>();
            var transaction = transactions.Find(x => x.Id == id);

            if (transaction is null)
                return null;

            transaction.StockId = request.StockId;
            transaction.PortfolioId = request.PortfolioId;
            transaction.Value = request.Value;
            transaction.Amount = request.Amount;

            serviceResponse.Data = transactions;
            return serviceResponse;
        }
    }
}
