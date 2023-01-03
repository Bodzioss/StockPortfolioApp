using Microsoft.AspNetCore.Mvc;

namespace StockPortfolioApp.Services.StockService
{
    public interface IStockService
    {
        List<Stock> GetAllStocks();
        Stock GetSingleStock(int id);
        List<Stock> AddStock(Stock stock);
        List<Stock> UpdateStock(int id, Stock request);
        List<Stock> DeleteStock(int id);
    }
}
