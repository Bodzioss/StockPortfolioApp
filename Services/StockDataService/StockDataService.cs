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

        public List<StockData> AddStockData(StockData stockData)
        {
            stockDatas.Add(stockData);
            return stockDatas;
        }

        public List<StockData> DeleteStockData(int id)
        {
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return null;

            stockDatas.Remove(stockData);

            return stockDatas;
        }

        public StockData GetSingleStockData(int id)
        {
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return null;

            return stockData;
        }

        public List<StockData> GetAllStockData()
        {
            return stockDatas;
        }

        public List<StockData> UpdateStockData(int id, StockData request)
        {
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                return null;

            stockData.StockId = request.StockId;
            stockData.Value = request.Value;
            stockData.Volume = request.Volume;
            stockData.RegisterTimestamp = request.RegisterTimestamp;

            return stockDatas;
        }
    }
}
