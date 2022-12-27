using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDataController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStockData()
        {
            var stockDataList = new List<StockData>()
            {
                new StockData
                {
                    Id = 1,
                    StockId = 1,
                    Value = 1,
                    Volume = 1,
                    RegisterTimestamp = DateTime.Now
                }
            };
            return Ok(stockDataList);
        }
    }
}
