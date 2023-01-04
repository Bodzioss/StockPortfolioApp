using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetAllPortfolios(); 
        Task<Portfolio> GetSinglePortfolio(int id); 
        Task<List<Portfolio>> AddPortfolio(Portfolio portfolio);
        Task<List<Portfolio>> UpdatePortfolio(int id, Portfolio request); 
        Task<List<Portfolio>> DeletePortfolio(int id);

    }
}
