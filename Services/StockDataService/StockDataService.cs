namespace StockPortfolioApp.Services.StockDataService
{
    public class StockDataService : IStockDataService
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

        public async Task<ServiceResponse<List<StockData>>> AddStockData(StockData stockData)
        {
            var serviceResponse = new ServiceResponse<List<StockData>>();
            stockDatas.Add(stockData);
            serviceResponse.Data = stockDatas;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<StockData>>> DeleteStockData(int id)
        {
            var serviceResponse = new ServiceResponse<List<StockData>>();
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return null;

            stockDatas.Remove(stockData);

            serviceResponse.Data = stockDatas;
            return serviceResponse;
        }

        public async Task<ServiceResponse<StockData>> GetSingleStockData(int id)
        {
            var serviceResponse = new ServiceResponse<StockData>();
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return null;

            serviceResponse.Data = stockData;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<StockData>>> GetAllStockData()
        {
            var serviceResponse = new ServiceResponse<List<StockData>>();
            serviceResponse.Data = stockDatas;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<StockData>>> UpdateStockData(int id, StockData request)
        {
            var serviceResponse = new ServiceResponse<List<StockData>>();
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return null;

            stockData.StockId = request.StockId;
            stockData.Value = request.Value;
            stockData.Volume = request.Volume;
            stockData.RegisterTimestamp = request.RegisterTimestamp;

            serviceResponse.Data = stockDatas;
            return serviceResponse;
        }
    }
}
