using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioComponentService
{
    public class PortfolioComponentService : IPortfolioComponentService
    {
        public static List<PortfolioComponent> portfolioComponents = new List<PortfolioComponent>{
                new PortfolioComponent
                {
                    Id = 1,
                    PortfolioId = 1,
                    StockId = 1,
                    Value = 195,
                    Amount = 1
                }
        };

        public async Task<ServiceResponse<List<PortfolioComponent>>> AddPortfolioComponent(PortfolioComponent portfolioComponent)
        {
            var serviceResponse = new ServiceResponse<List<PortfolioComponent>>();
            portfolioComponents.Add(portfolioComponent);
            serviceResponse.Data = portfolioComponents;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PortfolioComponent>>> DeletePortfolioComponent(int id)
        {
            var serviceResponse = new ServiceResponse<List<PortfolioComponent>>();
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);

            if (portfolioComponent == null)
                return null;

            portfolioComponents.Remove(portfolioComponent);

            serviceResponse.Data = portfolioComponents;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PortfolioComponent>>> GetAllPortfolioComponents()
        {
            var serviceResponse = new ServiceResponse<List<PortfolioComponent>>();
            serviceResponse.Data = portfolioComponents;
            return serviceResponse;
        }

        public async Task<ServiceResponse<PortfolioComponent>> GetSinglePortfolioComponent(int id)
        {
            var serviceResponse = new ServiceResponse<PortfolioComponent>();
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);

            if (portfolioComponent == null)
                return null;

            serviceResponse.Data = portfolioComponent;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PortfolioComponent>>> UpdatePortfolioComponent(int id, PortfolioComponent request)
        {
            var serviceResponse = new ServiceResponse<List<PortfolioComponent>>();
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);

            if (portfolioComponent == null)
                return null;

            portfolioComponent.PortfolioId = request.PortfolioId;
            portfolioComponent.StockId = request.StockId;
            portfolioComponent.Value = request.Value;
            portfolioComponent.Amount = request.Amount;

            serviceResponse.Data = portfolioComponents;
            return serviceResponse;
        }
    }
}
