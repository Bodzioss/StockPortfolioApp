using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.StockData;
using StockPortfolioApp.Services.StockDataService;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDataController : ControllerBase
    {
        private readonly IStockDataService _stockDataService;

        public StockDataController(IStockDataService stockDataService)
        {
            _stockDataService = stockDataService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetStockDataDto>>>> GetAllStockDatas()
        {
            return Ok(await _stockDataService.GetAllStockData());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStockDataDto>>> GetSingleStockData(int id)
        {
            var response = await _stockDataService.GetSingleStockData(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStockDataDto>>>> AddStockData(AddStockDataDto stockData)
        {
            return Ok(await _stockDataService.AddStockData(stockData));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStockDataDto>>>> UpdateStockData(int id, AddStockDataDto request)
        {
            var response = await _stockDataService.UpdateStockData(id,request);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStockDataDto>>>> DeleteStockData(int id)
        {
            var response = await _stockDataService.DeleteStockData(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
