using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.Stock;
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
        public async Task<ActionResult<ServiceResponse<List<GetStockDto>>>> GetAllStocks()
        {
            return Ok(await _stockService.GetAllStocks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStockDto>>> GetSingleStock(int id)
        {
            var response = await _stockService.GetSingleStock(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStockDto>>>> AddStock(AddStockDto stock)
        {
            return Ok(await _stockService.AddStock(stock));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStockDto>>>> UpdateStock(int id, AddStockDto request)
        {
            var response = await _stockService.UpdateStock(id,request);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStockDto>>>> DeleteStock(int id)
        {
            var response = await _stockService.DeleteStock(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
