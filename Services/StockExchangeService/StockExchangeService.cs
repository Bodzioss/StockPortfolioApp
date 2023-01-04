using StockPortfolioApp.Dtos.StockExchange;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.StockExchangeService
{
    public class StockExchangeService : IStockExchangeService
    {
        public static List<StockExchange> stockExchanges = new List<StockExchange>() {
                new StockExchange
                {
                    Id = 1,
                    Name = "1",
                    Country = "1"
                }
        };

        private readonly IMapper _mapper;

        public StockExchangeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetStockExchangeDto>>> AddStockExchange(AddStockExchangeDto stockExchange)
        {
            var serviceResponse = new ServiceResponse<List<GetStockExchangeDto>>();
            stockExchanges.Add(_mapper.Map<StockExchange>(stockExchange));
            serviceResponse.Data = stockExchanges.Select(stockExchange => _mapper.Map<GetStockExchangeDto>(stockExchange)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockExchangeDto>>> DeleteStockExchange(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStockExchangeDto>>();
            try
            {
                var stockExchange = stockExchanges.Find(x => x.Id == id);

                if (stockExchange is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");
                stockExchanges.Remove(stockExchange);

                serviceResponse.Data = stockExchanges.Select(stockExchange => _mapper.Map<GetStockExchangeDto>(stockExchange)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockExchangeDto>> GetSingleStockExchange(int id)
        {
            var serviceResponse = new ServiceResponse<GetStockExchangeDto>();
            try
            {
                var stockExchange = stockExchanges.Find(x => x.Id == id);

                if (stockExchange is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetStockExchangeDto>(stockExchange);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockExchangeDto>>> GetAllStockExchange()
        {
            var serviceResponse = new ServiceResponse<List<GetStockExchangeDto>>();
            serviceResponse.Data = stockExchanges.Select(stockExchange => _mapper.Map<GetStockExchangeDto>(stockExchange)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockExchangeDto>>> UpdateStockExchange(int id, AddStockExchangeDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetStockExchangeDto>>();
            try
            {
                var stockExchange = stockExchanges.FirstOrDefault(x => x.Id == id);

                if (stockExchange is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");

                stockExchange.Name = request.Name;
                stockExchange.Country = request.Country;

                serviceResponse.Data = stockExchanges.Select(stockExchange => _mapper.Map<GetStockExchangeDto>(stockExchange)).ToList();
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
