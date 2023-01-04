using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioComponentService
{
    public interface IPortfolioComponentService
    {
        Task<ServiceResponse<List<PortfolioComponent>>> GetAllPortfolioComponents();
        Task<ServiceResponse<PortfolioComponent>> GetSinglePortfolioComponent(int id);
        Task<ServiceResponse<List<PortfolioComponent>>> AddPortfolioComponent(PortfolioComponent portfolioComponent);
        Task<ServiceResponse<List<PortfolioComponent>>> UpdatePortfolioComponent(int id, PortfolioComponent request);
        Task<ServiceResponse<List<PortfolioComponent>>> DeletePortfolioComponent(int id);
    }
}
