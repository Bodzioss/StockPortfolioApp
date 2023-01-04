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

        public async Task<ServiceResponse<List<Stock>>> AddStock(Stock stock)
        {
            var serviceResponse = new ServiceResponse<List<Stock>>();
            stocks.Add(stock);
            serviceResponse.Data = stocks;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Stock>>> DeleteStock(int id)
        {
            var serviceResponse = new ServiceResponse<List<Stock>>();
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return null;

            stocks.Remove(stock);

            serviceResponse.Data = stocks;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Stock>>> GetAllStocks()
        {
            var serviceResponse = new ServiceResponse<List<Stock>>();
            serviceResponse.Data = stocks;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Stock>> GetSingleStock(int id)
        {
            var serviceResponse = new ServiceResponse<Stock>();
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return null;

            serviceResponse.Data = stock;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Stock>>> UpdateStock(int id, Stock request)
        {
            var serviceResponse = new ServiceResponse<List<Stock>>();
            var stock = stocks.Find(x => x.Id == id);

            if (stock == null)
                return null;

            stock.Name = request.Name;
            stock.Ticker = request.Ticker;
            stock.StockExchangeId = request.StockExchangeId;

            serviceResponse.Data = stocks;
            return serviceResponse;
        }
    }
}
