using Microsoft.AspNetCore.Mvc;

namespace StockPortfolioApp.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<List<Transaction>>> GetAllTransactions();
        Task<ServiceResponse<Transaction>> GetSingleTransaction(int id);
        Task<ServiceResponse<List<Transaction>>> AddTransaction(Transaction transaction);
        Task<ServiceResponse<List<Transaction>>> UpdateTransaction(int id, Transaction request);
        Task<ServiceResponse<List<Transaction>>> DeleteTransaction(int id);
    }
}
