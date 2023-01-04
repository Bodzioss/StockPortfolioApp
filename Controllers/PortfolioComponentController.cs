using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Services.PortfolioComponentService;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioComponentController : ControllerBase
    {
        private readonly IPortfolioComponentService _portfolioComponentService;

        public PortfolioComponentController(IPortfolioComponentService portfolioComponentService)
        {
            _portfolioComponentService = portfolioComponentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PortfolioComponent>>> GetAllPortfolioComponents()
        {
            return Ok(await _portfolioComponentService.GetAllPortfolioComponents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioComponent>> GetSinglePortfolioComponent(int id)
        {
            return Ok(await _portfolioComponentService.GetSinglePortfolioComponent(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<PortfolioComponent>>> AddPortfolioComponent(PortfolioComponent portfolioComponent)
        {
            return Ok(await _portfolioComponentService.AddPortfolioComponent(portfolioComponent));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<PortfolioComponent>>> UpdatePortfolioComponent(int id, PortfolioComponent request)
        {
            return Ok(await _portfolioComponentService.UpdatePortfolioComponent(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PortfolioComponent>>> DeletePortfolioComponent(int id)
        {
            return Ok(await _portfolioComponentService.DeletePortfolioComponent(id));
        }
    }
}
