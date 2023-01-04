﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Portfolio>>> GetAllPortfolios()
        {
            return Ok(_portfolioService.GetAllPortfolios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Portfolio>> GetSinglePortfolio(int id)
        {
            return Ok(_portfolioService.GetSinglePortfolio(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Portfolio>>> AddPortfolio(Portfolio portfolio)
        {
            return Ok(_portfolioService.AddPortfolio(portfolio));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Portfolio>>> UpdatePortfolio(int id, Portfolio request)
        {
            return Ok(_portfolioService.UpdatePortfolio(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Portfolio>>> DeletePortfolio(int id)
        {
            return Ok(_portfolioService.DeletePortfolio(id));
        }
    }
}