using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<ServiceResponse<List<Portfolio>>> GetAllPortfolios(); 
        Task<ServiceResponse<Portfolio>> GetSinglePortfolio(int id); 
        Task<ServiceResponse<List<Portfolio>>> AddPortfolio(Portfolio portfolio);
        Task<ServiceResponse<List<Portfolio>>> UpdatePortfolio(int id, Portfolio request); 
        Task<ServiceResponse<List<Portfolio>>> DeletePortfolio(int id);

    }
}
