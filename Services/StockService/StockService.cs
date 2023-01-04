using StockPortfolioApp.Dtos.Stock;
using StockPortfolioApp.Dtos.StockData;
using StockPortfolioApp.Models;

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
        private readonly IMapper _mapper;

        public StockService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetStockDto>>> AddStock(AddStockDto stock)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDto>>();
            stocks.Add(_mapper.Map<Stock>(stock));
            serviceResponse.Data = stocks.Select(stock => _mapper.Map<GetStockDto>(stock)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDto>>> DeleteStock(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDto>>();
            try
            {
                var stock = stocks.Find(x => x.Id == id);

                if (stock == null)
                    throw new Exception($"Stock with Id '{id}' not found.");

                stocks.Remove(stock);

                serviceResponse.Data = stocks.Select(stock => _mapper.Map<GetStockDto>(stock)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDto>>> GetAllStocks()
        {
            var serviceResponse = new ServiceResponse<List<GetStockDto>>();
            serviceResponse.Data = stocks.Select(stock => _mapper.Map<GetStockDto>(stock)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockDto>> GetSingleStock(int id)
        {
            var serviceResponse = new ServiceResponse<GetStockDto>();
            try
            {
                var stock = stocks.Find(x => x.Id == id);

                if (stock == null)
                    throw new Exception($"Stock with Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetStockDto>(stock);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDto>>> UpdateStock(int id, AddStockDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDto>>();
            try
            {
                var stock = stocks.Find(x => x.Id == id);

                if (stock == null)
                    throw new Exception($"Stock with Id '{id}' not found.");

                stock.Name = request.Name;
                stock.Ticker = request.Ticker;
                stock.StockExchangeId = request.StockExchangeId;

                serviceResponse.Data = stocks.Select(stock => _mapper.Map<GetStockDto>(stock)).ToList();
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
