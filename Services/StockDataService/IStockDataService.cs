using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.StockDataService
{
    public interface IStockDataService
    {
        Task<ServiceResponse<List<StockData>>> GetAllStockData(); 
        Task<ServiceResponse<StockData>> GetSingleStockData(int id);
        Task<ServiceResponse<List<StockData>>> AddStockData(StockData stockData);
        Task<ServiceResponse<List<StockData>>> UpdateStockData(int id, StockData request); 
        Task<ServiceResponse<List<StockData>>> DeleteStockData(int id);
    }
}
