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

        public List<Portfolio> AddPortfolio(Portfolio portfolio)
        {
            portfolios.Add(portfolio);
            return portfolios;
        }

        public List<Portfolio> DeletePortfolio(int id)
        {
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return null;

            portfolios.Remove(portfolio);
            return portfolios;
        }

        public List<Portfolio> GetAllPortfolios()
        {
            return portfolios;
        }

        public Portfolio GetSinglePortfolio(int id)
        {
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return null;

            return portfolio;
        }

        public List<Portfolio> UpdatePortfolio(int id, Portfolio request)
        {
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return null;

            portfolio.UserId = request.UserId;
            portfolio.Name = request.Name;
            portfolio.Description = request.Description;

            return portfolios;
        }
    }
}
