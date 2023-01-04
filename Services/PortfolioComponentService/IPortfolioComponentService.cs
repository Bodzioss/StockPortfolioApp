using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioComponentService
{
    public interface IPortfolioComponentService
    {
        Task<List<PortfolioComponent>> GetAllPortfolioComponents();
        Task<PortfolioComponent> GetSinglePortfolioComponent(int id);
        Task<List<PortfolioComponent>> AddPortfolioComponent(PortfolioComponent portfolioComponent);
        Task<List<PortfolioComponent>> UpdatePortfolioComponent(int id, PortfolioComponent request);
        Task<List<PortfolioComponent>> DeletePortfolioComponent(int id);
    }
}
