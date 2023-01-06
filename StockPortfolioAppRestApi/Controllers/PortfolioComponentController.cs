using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.PortfolioComponent;
using StockPortfolioApp.Services.PortfolioComponentService;
using System.Security.Claims;

namespace StockPortfolioApp.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<List<ServiceResponse<GetPortfolioComponentDto>>>> GetAllPortfolioComponents(int userId)
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _portfolioComponentService.GetAllPortfolioComponents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPortfolioComponentDto>>> GetSinglePortfolioComponent(int id)
        {
            var response = await _portfolioComponentService.GetSinglePortfolioComponent(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<ServiceResponse<GetPortfolioComponentDto>>>> AddPortfolioComponent(AddPortfolioComponentDto portfolioComponent)
        {
            return Ok(await _portfolioComponentService.AddPortfolioComponent(portfolioComponent));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ServiceResponse<GetPortfolioComponentDto>>>> UpdatePortfolioComponent(int id, AddPortfolioComponentDto request)
        {
            var response = await _portfolioComponentService.UpdatePortfolioComponent(id,request);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ServiceResponse<GetPortfolioComponentDto>>>> DeletePortfolioComponent(int id)
        {
            var response = await _portfolioComponentService.DeletePortfolioComponent(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
