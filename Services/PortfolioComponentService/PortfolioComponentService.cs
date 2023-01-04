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

        public async Task<List<PortfolioComponent>> AddPortfolioComponent(PortfolioComponent portfolioComponent)
        {
            portfolioComponents.Add(portfolioComponent);
            return portfolioComponents;
        }

        public async Task<List<PortfolioComponent>> DeletePortfolioComponent(int id)
        {
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);


            if (portfolioComponent == null)
                return null;

            portfolioComponents.Remove(portfolioComponent);

            return portfolioComponents;
        }

        public async Task<List<PortfolioComponent>> GetAllPortfolioComponents()
        {
            return portfolioComponents;
        }

        public async Task<PortfolioComponent> GetSinglePortfolioComponent(int id)
        {
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);

            if (portfolioComponent == null)
                return null;

            return portfolioComponent;
        }

        public async Task<List<PortfolioComponent>> UpdatePortfolioComponent(int id, PortfolioComponent request)
        {
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);

            if (portfolioComponent == null)
                return null;

            portfolioComponent.PortfolioId = request.PortfolioId;
            portfolioComponent.StockId = request.StockId;
            portfolioComponent.Value = request.Value;
            portfolioComponent.Amount = request.Amount;

            return portfolioComponents;
        }
    }
}
