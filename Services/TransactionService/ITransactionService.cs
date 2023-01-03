using Microsoft.AspNetCore.Mvc;

namespace StockPortfolioApp.Services.TransactionService
{
    public interface ITransactionService
    {
        List<Transaction> GetAllTransactions();
        Transaction GetSingleTransaction(int id);
        List<Transaction> AddTransaction(Transaction transaction);
        List<Transaction> UpdateTransaction(int id, Transaction request);
        List<Transaction> DeleteTransaction(int id);
    }
}
