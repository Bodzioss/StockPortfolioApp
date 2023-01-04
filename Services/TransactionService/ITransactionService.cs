using Microsoft.AspNetCore.Mvc;

namespace StockPortfolioApp.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllTransactions();
        Task<Transaction> GetSingleTransaction(int id);
        Task<List<Transaction>> AddTransaction(Transaction transaction);
        Task<List<Transaction>> UpdateTransaction(int id, Transaction request);
        Task<List<Transaction>> DeleteTransaction(int id);
    }
}
