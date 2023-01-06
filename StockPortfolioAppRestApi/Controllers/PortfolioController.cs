using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.Portfolio;
using StockPortfolioApp.Services.PortfolioService;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetPortfolioDto>>>> GetAllPortfolios()
        {
            return Ok(await _portfolioService.GetAllPortfolios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPortfolioDto>>> GetSinglePortfolio(int id)
        {
            var response = await _portfolioService.GetSinglePortfolio(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPortfolioDto>>>> AddPortfolio(AddPortfolioDto portfolio)
        {
            return Ok(await _portfolioService.AddPortfolio(portfolio));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPortfolioDto>>>> UpdatePortfolio(int id, AddPortfolioDto request)
        {
            var response = await _portfolioService.UpdatePortfolio(id,request);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPortfolioDto>>>> DeletePortfolio(int id)
        {
            var response = await _portfolioService.DeletePortfolio(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
