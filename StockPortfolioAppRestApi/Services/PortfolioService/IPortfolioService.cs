using StockPortfolioApp.Dtos.Portfolio;

namespace StockPortfolioApp.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<ServiceResponse<List<GetPortfolioDto>>> GetAllPortfolios(); 
        Task<ServiceResponse<GetPortfolioDto>> GetSinglePortfolio(int id); 
        Task<ServiceResponse<List<GetPortfolioDto>>> AddPortfolio(AddPortfolioDto portfolio);
        Task<ServiceResponse<List<GetPortfolioDto>>> UpdatePortfolio(int id, AddPortfolioDto request); 
        Task<ServiceResponse<List<GetPortfolioDto>>> DeletePortfolio(int id);

    }
}
