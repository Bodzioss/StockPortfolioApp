﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDataController : ControllerBase
    {
        public static List<StockData> stockDatas = new List<StockData>() { 
                new StockData
                {
                    Id = 1,
                    StockId = 1,
                    Value = 1,
                    Volume = 1,
                    RegisterTimestamp = DateTime.Now
                }
        };

        [HttpGet]
        public async Task<ActionResult<List<StockData>>> GetAllStockDatas()
        {
            return Ok(stockDatas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StockData>> GetSingleStockData(int id)
        {
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return NotFound("Sorry, but this StockData does not exist.");

            return Ok(stockData);
        }

        [HttpPost]
        public async Task<ActionResult<List<StockData>>> AddStockData(StockData stockData)
        {
            stockDatas.Add(stockData);
            return Ok(stockDatas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<StockData>>> UpdateStockData(int id, StockData request)
        {
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return NotFound("Sorry, but this StockData does not exist.");

            stockData.StockId = request.StockId;
            stockData.Value = request.Value;
            stockData.Volume = request.Volume;
            stockData.RegisterTimestamp = request.RegisterTimestamp;

            return Ok(stockDatas);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StockData>>> DeleteStockData(int id)
        {
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return NotFound("Sorry, but this StockData does not exist.");

            stockDatas.Remove(stockData);

            return Ok(stockDatas);
        }
    }
}
