using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioService
{
    public interface IPortfolioService
    {
        List<Portfolio> GetAllPortfolios();
        Portfolio GetSinglePortfolio(int id);
        List<Portfolio> AddPortfolio(Portfolio portfolio);
        List<Portfolio> UpdatePortfolio(int id, Portfolio request);
        List<Portfolio> DeletePortfolio(int id);

    }
}
