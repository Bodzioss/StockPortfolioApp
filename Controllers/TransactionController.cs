using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Services.TransactionService;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> GetAllTransactions()
        {
            return Ok(await _transactionService.GetAllTransactions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Transaction>>> GetSingleTransaction(int id)
        {
            return Ok(await _transactionService.GetSingleTransaction(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> AddTransaction(Transaction transaction)
        {
            return Ok(await _transactionService.AddTransaction(transaction));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> UpdateTransaction(int id, Transaction request)
        {
            return Ok(await _transactionService.UpdateTransaction(id, request));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> DeleteTransaction(int id)
        {
            return Ok(await _transactionService.DeleteTransaction(id));
        }
    }
}
