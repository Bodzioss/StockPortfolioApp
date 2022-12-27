using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioComponentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioComponents()
        {
            var portfolioComponentList = new List<PortfolioComponent>()
            {
                new PortfolioComponent
                {
                    Id = 1,
                    PortfolioId = 1,
                    StockId = 1,
                    Value = 195,
                    Amount = 1
                }
            };
            return Ok(portfolioComponentList);
        }
    }
}
