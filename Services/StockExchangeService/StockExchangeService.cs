using StockPortfolioApp.Dtos.StockExchange;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.StockExchangeService
{
    public class StockExchangeService : IStockExchangeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StockExchangeService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetStockExchangeDto>>> AddStockExchange(AddStockExchangeDto stockExchange)
        {
            var serviceResponse = new ServiceResponse<List<GetStockExchangeDto>>();
            _context.StockExchange.Add(_mapper.Map<StockExchange>(stockExchange));
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.StockExchange.Select(stockExchange => _mapper.Map<GetStockExchangeDto>(stockExchange)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockExchangeDto>>> DeleteStockExchange(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStockExchangeDto>>();
            try
            {
                var stockExchange = await _context.StockExchange.FirstOrDefaultAsync(x => x.Id == id);

                if (stockExchange is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");
                _context.StockExchange.Remove(stockExchange);

                serviceResponse.Data = await _context.StockExchange.Select(stockExchange => _mapper.Map<GetStockExchangeDto>(stockExchange)).ToListAsync();
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
                var stockExchange = await _context.StockExchange.FirstOrDefaultAsync(x => x.Id == id);

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
            serviceResponse.Data = await _context.StockExchange.Select(stockExchange => _mapper.Map<GetStockExchangeDto>(stockExchange)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockExchangeDto>>> UpdateStockExchange(int id, AddStockExchangeDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetStockExchangeDto>>();
            try
            {
                var stockExchange = await _context.StockExchange.FirstOrDefaultAsync(x => x.Id == id);

                if (stockExchange is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");

                stockExchange.Name = request.Name;
                stockExchange.Country = request.Country;

                serviceResponse.Data = await _context.StockExchange.Select(stockExchange => _mapper.Map<GetStockExchangeDto>(stockExchange)).ToListAsync();
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
