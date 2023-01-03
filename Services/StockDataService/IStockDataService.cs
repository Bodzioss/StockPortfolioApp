using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.StockDataService
{
    public interface IStockDataService
    {
        List<StockData> GetStockData();
        StockData GetSingleStockData(int id);
        List<StockData> AddStockData(StockData stockData);
        List<StockData> UpdateStockData(int id, StockData request);

        List<StockData> DeleteStockData(int id);

    }
}
