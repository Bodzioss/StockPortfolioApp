using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolios()
        {
            var portfolioList = new List<Portfolio>()
            {
                new Portfolio
                {
                    Id = 1,
                    UserId = 1,
                    Name = "First Portfolio Name",
                    Description = "First Portfolio Description",           
                }
            };
            return Ok(portfolioList);
        }
    }
}
