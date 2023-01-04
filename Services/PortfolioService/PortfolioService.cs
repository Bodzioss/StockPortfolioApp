using StockPortfolioApp.Dtos.Portfolio;
using StockPortfolioApp.Dtos.PortfolioComponent;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.PortfolioService
{
    public class PortfolioService : IPortfolioService
    {
        public static List<Portfolio> portfolios = new List<Portfolio> {
                new Portfolio
                {
                    Id = 1,
                    UserId = 1,
                    Name = "First Portfolio Name",
                    Description = "First Portfolio Description",
                }
        };
        private readonly IMapper _mapper;

        public PortfolioService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetPortfolioDto>>> AddPortfolio(AddPortfolioDto portfolio)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioDto>>();
            portfolios.Add(_mapper.Map<Portfolio>(portfolio));
            serviceResponse.Data = portfolios.Select(portfolio => _mapper.Map<GetPortfolioDto>(portfolio)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioDto>>> DeletePortfolio(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioDto>>();
            try
            {
                var portfolio = portfolios.FirstOrDefault(x => x.Id == id);

                if (portfolio == null)
                    throw new Exception($"Portfolio with Id '{id}' not found.");

                portfolios.Remove(portfolio);
                serviceResponse.Data = portfolios.Select(portfolio => _mapper.Map<GetPortfolioDto>(portfolio)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioDto>>> GetAllPortfolios()
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioDto>>();
            serviceResponse.Data = portfolios.Select(portfolio => _mapper.Map<GetPortfolioDto>(portfolio)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPortfolioDto>> GetSinglePortfolio(int id)
        {
            var serviceResponse = new ServiceResponse<GetPortfolioDto>();
            try
            {
                var portfolio = portfolios.FirstOrDefault(x => x.Id == id);

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
                var portfolio = portfolios.FirstOrDefault(x => x.Id == id);

                if (portfolio == null)
                    throw new Exception($"Portfolio with Id '{id}' not found.");

                portfolio.UserId = request.UserId;
                portfolio.Name = request.Name;
                portfolio.Description = request.Description;

                serviceResponse.Data = portfolios.Select(portfolio => _mapper.Map<GetPortfolioDto>(portfolio)).ToList();
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
