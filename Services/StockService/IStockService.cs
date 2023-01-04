using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.Stock;

namespace StockPortfolioApp.Services.StockService
{
    public interface IStockService
    {
        Task<ServiceResponse<List<GetStockDto>>> GetAllStocks(); 
        Task<ServiceResponse<GetStockDto>> GetSingleStock(int id); 
        Task<ServiceResponse<List<GetStockDto>>> AddStock(AddStockDto stock); 
        Task<ServiceResponse<List<GetStockDto>>> UpdateStock(int id, AddStockDto request); 
        Task<ServiceResponse<List<GetStockDto>>> DeleteStock(int id);
    }
}
