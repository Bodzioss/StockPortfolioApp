using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.Transaction;

namespace StockPortfolioApp.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransactions();
        Task<ServiceResponse<GetTransactionDto>> GetSingleTransaction(int id);
        Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto transaction);
        Task<ServiceResponse<List<GetTransactionDto>>> UpdateTransaction(int id, AddTransactionDto request);
        Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int id);
    }
}
