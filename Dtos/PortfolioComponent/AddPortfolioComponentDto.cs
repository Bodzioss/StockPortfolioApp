﻿namespace StockPortfolioApp.Dtos.PortfolioComponent
{
    public class AddPortfolioComponentDto
    {
        public int PortfolioId { get; set; }
        public int StockId { get; set; }
        public Decimal Value { get; set; }
        public int Amount { get; set; }
    }
}
