using StockPortfolioApp.Dtos.Portfolio;
using StockPortfolioApp.Dtos.StockData;
using StockPortfolioApp.Models;

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
        private readonly IMapper _mapper;

        public StockDataService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetStockDataDto>>> AddStockData(AddStockDataDto stockData)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDataDto>>();
            stockDatas.Add(_mapper.Map<StockData>(stockData));
            serviceResponse.Data = stockDatas.Select(stockData => _mapper.Map<GetStockDataDto>(stockData)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDataDto>>> DeleteStockData(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDataDto>>();
            try
            { 
            var stockData = stockDatas.Find(x => x.Id == id);

            if (stockData is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");

                stockDatas.Remove(stockData);

            serviceResponse.Data = stockDatas.Select(stockData => _mapper.Map<GetStockDataDto>(stockData)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockDataDto>> GetSingleStockData(int id)
        {
            var serviceResponse = new ServiceResponse<GetStockDataDto>();
            try
            { 
                var stockData = stockDatas.Find(x => x.Id == id);

                if (stockData is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetStockDataDto>(stockData);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDataDto>>> GetAllStockData()
        {
            var serviceResponse = new ServiceResponse<List<GetStockDataDto>>();
            serviceResponse.Data = stockDatas.Select(stockData => _mapper.Map<GetStockDataDto>(stockData)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDataDto>>> UpdateStockData(int id, AddStockDataDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDataDto>>();
            try
            { 
                var stockData = stockDatas.FirstOrDefault(x => x.Id == id);

                if (stockData is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");

                stockData.StockId = request.StockId;
                stockData.Value = request.Value;
                stockData.Volume = request.Volume;
                stockData.RegisterTimestamp = request.RegisterTimestamp;

                serviceResponse.Data = stockDatas.Select(stockData => _mapper.Map<GetStockDataDto>(stockData)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
