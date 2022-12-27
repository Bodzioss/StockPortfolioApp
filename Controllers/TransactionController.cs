using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactionList = new List<Transaction>()
            {
                new Transaction
                {
                    Id = 1,
                    StockId = 1,
                    PortfolioId = 1,
                    Value = 1,
                    Amount = 1
                }
            };
            return Ok(transactionList);
        }
    }
}
