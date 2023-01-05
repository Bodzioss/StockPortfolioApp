using StockPortfolioApp.Dtos.Portfolio;
using StockPortfolioApp.Dtos.StockData;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.StockDataService
{
    public class StockDataService : IStockDataService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StockDataService(IMapper mapper, DataContext context)
        {
            _context = context
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetStockDataDto>>> AddStockData(AddStockDataDto stockData)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDataDto>>();
            _context.StockDatas.Add(_mapper.Map<StockData>(stockData));
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.StockDatas.Select(stockData => _mapper.Map<GetStockDataDto>(stockData)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDataDto>>> DeleteStockData(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDataDto>>();
            try
            { 
                var stockData = await _context.StockDatas.FirstOrDefaultAsync(x => x.Id == id);

                if (stockData is null)
                        throw new Exception($"Stock data with Id '{id}' not found.");

                _context.StockDatas.Remove(stockData);

                serviceResponse.Data = await _context.StockDatas.Select(stockData => _mapper.Map<GetStockDataDto>(stockData)).ToListAsync();
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
                var stockData = await _context.StockDatas.FirstOrDefaultAsync(x => x.Id == id);

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
            serviceResponse.Data = await _context.StockDatas.Select(stockData => _mapper.Map<GetStockDataDto>(stockData)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockDataDto>>> UpdateStockData(int id, AddStockDataDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetStockDataDto>>();
            try
            { 
                var stockData = await _context.StockDatas.FirstOrDefaultAsync(x => x.Id == id);

                if (stockData is null)
                    throw new Exception($"Stock data with Id '{id}' not found.");

                stockData.StockId = request.StockId;
                stockData.Value = request.Value;
                stockData.Volume = request.Volume;
                stockData.RegisterTimestamp = request.RegisterTimestamp;

                serviceResponse.Data = await _context.StockDatas.Select(stockData => _mapper.Map<GetStockDataDto>(stockData)).ToListAsync();
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
