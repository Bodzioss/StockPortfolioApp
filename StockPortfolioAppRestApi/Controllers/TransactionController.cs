using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.Transaction;
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
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> GetAllTransactions()
        {
            return Ok(await _transactionService.GetAllTransactions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> GetSingleTransaction(int id)
        {
            var response = await _transactionService.GetSingleTransaction(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> AddTransaction(AddTransactionDto transaction)
        {
            return Ok(await _transactionService.AddTransaction(transaction));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> UpdateTransaction(int id, AddTransactionDto request)
        {
            var response = await _transactionService.UpdateTransaction(id,request);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> DeleteTransaction(int id)
        {
            var response = await _transactionService.DeleteTransaction(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
