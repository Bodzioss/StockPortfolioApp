using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioComponentController : ControllerBase
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
      

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioComponents()
        {
            return Ok(portfolioComponents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePortfolioComponent(int id)
        {
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);
            return Ok(portfolioComponent);
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolioComponent(PortfolioComponent portfolioComponent)
        {
            portfolioComponents.Add(portfolioComponent);
            return Ok(portfolioComponent);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortfolioComponent(int id, PortfolioComponent request)
        {
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);

            portfolioComponent.PortfolioId = request.PortfolioId;
            portfolioComponent.StockId = request.StockId;
            portfolioComponent.Value = request.Value;
            portfolioComponent.Amount = request.Amount;

            return Ok(portfolioComponents);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolioComponent(int id)
        {
            var portfolioComponent = portfolioComponents.Find(x => x.Id == id);

            portfolioComponents.Remove(portfolioComponent);

            return Ok(portfolioComponents);
        }
    }
}
