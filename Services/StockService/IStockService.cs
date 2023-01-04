using Microsoft.AspNetCore.Mvc;

namespace StockPortfolioApp.Services.StockService
{
    public interface IStockService
    {
        Task<ServiceResponse<List<Stock>>> GetAllStocks(); 
        Task<ServiceResponse<Stock>> GetSingleStock(int id); 
        Task<ServiceResponse<List<Stock>>> AddStock(Stock stock); 
        Task<ServiceResponse<List<Stock>>> UpdateStock(int id, Stock request); 
        Task<ServiceResponse<List<Stock>>> DeleteStock(int id);
    }
}
