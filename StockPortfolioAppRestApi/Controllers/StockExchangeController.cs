using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.StockExchange;
using StockPortfolioApp.Services.StockExchangeService;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        private readonly IStockExchangeService _stockDataService;

        public StockExchangeController(IStockExchangeService stockDataService)
        {
            _stockDataService = stockDataService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetStockExchangeDto>>>> GetAllStockExchanges()
        {
            return Ok(await _stockDataService.GetAllStockExchange());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStockExchangeDto>>> GetSingleStockExchange(int id)
        {
            var response = await _stockDataService.GetSingleStockExchange(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStockExchangeDto>>>> AddStockExchange(AddStockExchangeDto stockData)
        {
            return Ok(await _stockDataService.AddStockExchange(stockData));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStockExchangeDto>>>> UpdateStockExchange(int id, AddStockExchangeDto request)
        {
            var response = await _stockDataService.UpdateStockExchange(id, request);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStockExchangeDto>>>> DeleteStockExchange(int id)
        {
            var response = await _stockDataService.DeleteStockExchange(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
