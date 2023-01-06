using StockPortfolioApp.Dtos.Stock;
using StockPortfolioApp.Dtos.StockData;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.StockService
{
    public class StockService : IStockService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StockService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetStockDto>>> AddStock(AddStockDto stock)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDto>>();
            _context.Stocks.Add(_mapper.Map<Stock>(stock));
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Stocks.Select(stock => _mapper.Map<GetStockDto>(stock)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDto>>> DeleteStock(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDto>>();
            try
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

                if (stock == null)
                    throw new Exception($"Stock with Id '{id}' not found.");

                _context.Stocks.Remove(stock);

                serviceResponse.Data = await _context.Stocks.Select(stock => _mapper.Map<GetStockDto>(stock)).ToListAsync();
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
            serviceResponse.Data = await _context.Stocks.Select(stock => _mapper.Map<GetStockDto>(stock)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockDto>> GetSingleStock(int id)
        {
            var serviceResponse = new ServiceResponse<GetStockDto>();
            try
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

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
                var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

                if (stock == null)
                    throw new Exception($"Stock with Id '{id}' not found.");

                stock.Name = request.Name;
                stock.Ticker = request.Ticker;
                stock.StockExchangeId = request.StockExchangeId;

                serviceResponse.Data = await _context.Stocks.Select(stock => _mapper.Map<GetStockDto>(stock)).ToListAsync();
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
