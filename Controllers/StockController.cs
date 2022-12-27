using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stockList = new List<Stock>()
            {
                new Stock
                {
                    Id = 1,
                    Name = "CDProjektRed",
                    Ticker = "CDP",
                    StockExchangeId = 1
                }
            };
            return Ok(stockList);
        }
    }
}
