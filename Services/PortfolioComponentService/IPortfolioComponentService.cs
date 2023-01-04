using StockPortfolioApp.Dtos.PortfolioComponent;

namespace StockPortfolioApp.Services.PortfolioComponentService
{
    public interface IPortfolioComponentService
    {
        Task<ServiceResponse<List<GetPortfolioComponentDto>>> GetAllPortfolioComponents();
        Task<ServiceResponse<GetPortfolioComponentDto>> GetSinglePortfolioComponent(int id);
        Task<ServiceResponse<List<GetPortfolioComponentDto>>> AddPortfolioComponent(AddPortfolioComponentDto portfolioComponent);
        Task<ServiceResponse<List<GetPortfolioComponentDto>>> UpdatePortfolioComponent(int id, AddPortfolioComponentDto request);
        Task<ServiceResponse<List<GetPortfolioComponentDto>>> DeletePortfolioComponent(int id);
    }
}
