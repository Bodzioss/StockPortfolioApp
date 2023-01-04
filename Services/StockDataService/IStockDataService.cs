using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.StockDataService
{
    public interface IStockDataService
    {
        Task<List<StockData>> GetAllStockData(); 
        Task<StockData> GetSingleStockData(int id);
        Task<List<StockData>> AddStockData(StockData stockData);
        Task<List<StockData>> UpdateStockData(int id, StockData request); 
        Task<List<StockData>> DeleteStockData(int id);
    }
}
