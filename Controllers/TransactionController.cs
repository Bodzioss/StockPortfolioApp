using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private static List<Transaction> transactions = new List<Transaction> {
            new Transaction
            {
                Id = 1,
                StockId = 1,
                PortfolioId = 1,
                Value = 1,
                Amount = 1
            }
        };

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTransaction(int id)
        {
            var transaction = transactions.Find(x => x.Id == id);
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
            return Ok(transactions);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(int id, Transaction request)
        {
            var transaction = transactions.Find(x => x.Id == id);

            if(transaction is null)
                return NotFound("Sorry, but this transaction does not exists.");

            transaction.StockId = request.StockId;
            transaction.PortfolioId= request.PortfolioId;
            transaction.Value = request.Value;
            transaction.Amount = request.Amount;

            return Ok(transaction);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = transactions.Find(x => x.Id == id);

            if (transaction is null)
                return NotFound("Sorry, but this transaction does not exists.");

            transactions.Remove(transaction);
            return Ok(transactions);
        }
    }
}
