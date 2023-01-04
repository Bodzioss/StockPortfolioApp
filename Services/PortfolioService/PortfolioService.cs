using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioService
{
    public class PortfolioService : IPortfolioService
    {
        public static List<Portfolio> portfolios = new List<Portfolio> {
                new Portfolio
                {
                    Id = 1,
                    UserId = 1,
                    Name = "First Portfolio Name",
                    Description = "First Portfolio Description",
                }
        };

        public async Task<ServiceResponse<List<Portfolio>>> AddPortfolio(Portfolio portfolio)
        {
            var serviceResponse = new ServiceResponse<List<Portfolio>>();
            portfolios.Add(portfolio);
            serviceResponse.Data = portfolios;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Portfolio>>> DeletePortfolio(int id)
        {
            var serviceResponse = new ServiceResponse<List<Portfolio>>();
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return null;

            portfolios.Remove(portfolio);
            serviceResponse.Data = portfolios;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Portfolio>>> GetAllPortfolios()
        {
            var serviceResponse = new ServiceResponse<List<Portfolio>>();
            serviceResponse.Data = portfolios;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Portfolio>> GetSinglePortfolio(int id)
        {
            var serviceResponse = new ServiceResponse<Portfolio>();
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return null;

            serviceResponse.Data = portfolio;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Portfolio>>> UpdatePortfolio(int id, Portfolio request)
        {
            var serviceResponse = new ServiceResponse<List<Portfolio>>();
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return null;

            portfolio.UserId = request.UserId;
            portfolio.Name = request.Name;
            portfolio.Description = request.Description;

            serviceResponse.Data = portfolios;
            return serviceResponse;
        }
    }
}
