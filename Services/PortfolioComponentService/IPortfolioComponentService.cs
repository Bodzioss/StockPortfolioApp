using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioComponentService
{
    public interface IPortfolioComponentService
    {
        List<PortfolioComponent> GetAllPortfolioComponents();
        PortfolioComponent GetSinglePortfolioComponent(int id);
        List<PortfolioComponent> AddPortfolioComponent(PortfolioComponent portfolioComponent);
        List<PortfolioComponent> UpdatePortfolioComponent(int id, PortfolioComponent request);
        List<PortfolioComponent> DeletePortfolioComponent(int id);
    }
}
