using Microsoft.EntityFrameworkCore;
using StockPortfolioApp.Dtos.Portfolio;
using StockPortfolioApp.Dtos.PortfolioComponent;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioService
{
    public class PortfolioService : IPortfolioService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PortfolioService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetPortfolioDto>>> AddPortfolio(AddPortfolioDto portfolio)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioDto>>();
            _context.Portfolios.Add(_mapper.Map<Portfolio>(portfolio));
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Portfolios.Select(portfolio => _mapper.Map<GetPortfolioDto>(portfolio)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioDto>>> DeletePortfolio(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioDto>>();
            try
            {
                var portfolio = await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == id);

                if (portfolio == null)
                    throw new Exception($"Portfolio with Id '{id}' not found.");

                _context.Portfolios.Remove(portfolio);

                serviceResponse.Data = await _context.Portfolios.Select(portfolio => _mapper.Map<GetPortfolioDto>(portfolio)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioDto>>> GetAllPortfolios(int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioDto>>();
            serviceResponse.Data = await _context.Portfolios.Where(c => c.UserId == userId).Select(portfolio => _mapper.Map<GetPortfolioDto>(portfolio)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPortfolioDto>> GetSinglePortfolio(int id)
        {
            var serviceResponse = new ServiceResponse<GetPortfolioDto>();
            try
            {
                var portfolio = await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == id);

                if (portfolio == null)
                    throw new Exception($"Portfolio with Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetPortfolioDto>(portfolio);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioDto>>> UpdatePortfolio(int id, AddPortfolioDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioDto>>();
            try
            {
                var portfolio = await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == id);

                if (portfolio == null)
                    throw new Exception($"Portfolio with Id '{id}' not found.");

                portfolio.UserId = request.UserId;
                portfolio.Name = request.Name;
                portfolio.Description = request.Description;

                serviceResponse.Data = await _context.Portfolios.Select(portfolio => _mapper.Map<GetPortfolioDto>(portfolio)).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
