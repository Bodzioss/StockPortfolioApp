using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
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

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolios()
        {
            return Ok(portfolios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePortfolio(int id)
        {
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return NotFound("Sorry, but this portfolio does not exist.");

            return Ok(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(Portfolio portfolio)
        {
            portfolios.Add(portfolio);
            return Ok(portfolio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortfolio(int id, Portfolio request)
        {
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return NotFound("Sorry, but this portfolio does not exist.");

            portfolio.UserId = request.UserId;
            portfolio.Name = request.Name;
            portfolio.Description = request.Description;

            return Ok(portfolios);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var portfolio = portfolios.Find(x => x.Id == id);

            if (portfolio == null)
                return NotFound("Sorry, but this portfolio does not exist.");

            portfolios.Remove(portfolio);
            return Ok(portfolio);
        }
    }
}
