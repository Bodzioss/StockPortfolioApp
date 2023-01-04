﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Transaction>>> GetAllTransactions()
        {
            return Ok(_transactionService.GetAllTransactions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetSingleTransaction(int id)
        {
            return Ok(_transactionService.GetSingleTransaction(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Transaction>>> AddTransaction(Transaction transaction)
        {
            return Ok(_transactionService.AddTransaction(transaction));
        }

        [HttpPut]
        public async Task<ActionResult<List<Transaction>>> UpdateTransaction(int id, Transaction request)
        {
            return Ok(_transactionService.UpdateTransaction(id, request));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Transaction>>> DeleteTransaction(int id)
        {
            return Ok(_transactionService.DeleteTransaction(id));
        }
    }
}
