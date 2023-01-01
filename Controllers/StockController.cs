using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        public static List<Stock> stocks = new List<Stock> { 
                new Stock
                {
                    Id = 1,
                    Name = "CDProjektRed",
                    Ticker = "CDP",
                    StockExchangeId = 1
                }
        };
 

        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleStock(int id)
        {
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return NotFound("Sorry, but this stock does not exist.");

            return Ok(stocks);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock(Stock stock)
        {
            stocks.Add(stock);
            return Ok(stocks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int id, Stock request)
        {
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return NotFound("Sorry, but this stock does not exist.");

            stock.Name = request.Name;
            stock.Ticker = request.Ticker;
            stock.StockExchangeId= request.StockExchangeId;

            return Ok(stocks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return NotFound("Sorry, but this stock does not exist.");

            stocks.Remove(stock);

            return Ok(stocks);
        }
    }
}
