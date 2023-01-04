using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<StockData>>> GetAllStockDatas()
        {
            return Ok(_stockDataService.GetAllStockData());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StockData>> GetSingleStockData(int id)
        {
            return Ok(_stockDataService.GetSingleStockData(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<StockData>>> AddStockData(StockData stockData)
        {
            return Ok(_stockDataService.AddStockData(stockData));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<StockData>>> UpdateStockData(int id, StockData request)
        {
            return Ok(_stockDataService.UpdateStockData(id,request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StockData>>> DeleteStockData(int id)
        {
            return Ok(_stockDataService.DeleteStockData(id));
        }
    }
}
