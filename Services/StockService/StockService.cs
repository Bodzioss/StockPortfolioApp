namespace StockPortfolioApp.Services.StockService
{
    public class StockService : IStockService
    {
        public static List<Stock> stocks = new List<Stock> {
                new Stock
                {
                    Id = 1,
                    Name = "CDProjektRed",
                    Ticker = "CDP",
                    StockExchangeId = 1
                }
        };

        public async Task<List<Stock>> AddStock(Stock stock)
        {
            stocks.Add(stock);
            return stocks;
        }

        public async Task<List<Stock>> DeleteStock(int id)
        {
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return null;

            stocks.Remove(stock);

            return stocks;
        }

        public async Task<List<Stock>> GetAllStocks()
        {
            return stocks;
        }

        public async Task<Stock> GetSingleStock(int id)
        {
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return null;

            return stock;
        }

        public async Task<List<Stock>> UpdateStock(int id, Stock request)
        {
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return null;

            stock.Name = request.Name;
            stock.Ticker = request.Ticker;
            stock.StockExchangeId = request.StockExchangeId;

            return stocks;
        }
    }
}
