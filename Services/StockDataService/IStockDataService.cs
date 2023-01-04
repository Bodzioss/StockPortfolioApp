using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.StockData;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.StockDataService
{
    public interface IStockDataService
    {
        Task<ServiceResponse<List<GetStockDataDto>>> GetAllStockData(); 
        Task<ServiceResponse<GetStockDataDto>> GetSingleStockData(int id);
        Task<ServiceResponse<List<GetStockDataDto>>> AddStockData(AddStockDataDto stockData);
        Task<ServiceResponse<List<GetStockDataDto>>> UpdateStockData(int id, AddStockDataDto request); 
        Task<ServiceResponse<List<GetStockDataDto>>> DeleteStockData(int id);
    }
}
