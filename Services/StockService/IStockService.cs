using Microsoft.AspNetCore.Mvc;

namespace StockPortfolioApp.Services.StockService
{
    public interface IStockService
    {
        Task<List<Stock>> GetAllStocks(); 
        Task<Stock> GetSingleStock(int id); 
        Task<List<Stock>> AddStock(Stock stock); 
        Task<List<Stock>> UpdateStock(int id, Stock request); 
        Task<List<Stock>> DeleteStock(int id);
    }
}
