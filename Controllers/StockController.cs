using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Services.StockService;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> GetAllStocks()
        {
            return Ok(_stockService.GetAllStocks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetSingleStock(int id)
        {
            return Ok(_stockService.GetSingleStock(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Stock>>> AddStock(Stock stock)
        {
            return Ok(_stockService.AddStock(stock));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Stock>>> UpdateStock(int id, Stock request)
        {
            return Ok(_stockService.UpdateStock(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Stock>>> DeleteStock(int id)
        {
            return Ok(_stockService.DeleteStock(id));
        }
    }
}
