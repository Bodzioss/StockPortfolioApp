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
        public async Task<ActionResult<ServiceResponse<List<Stock>>>> GetAllStocks()
        {
            return Ok(await _stockService.GetAllStocks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Stock>>> GetSingleStock(int id)
        {
            return Ok(await _stockService.GetSingleStock(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Stock>>>> AddStock(Stock stock)
        {
            return Ok(await _stockService.AddStock(stock));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Stock>>>> UpdateStock(int id, Stock request)
        {
            return Ok(await _stockService.UpdateStock(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Stock>>>> DeleteStock(int id)
        {
            return Ok(await _stockService.DeleteStock(id));
        }
    }
}
