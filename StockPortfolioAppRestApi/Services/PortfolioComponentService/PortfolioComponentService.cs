using StockPortfolioApp.Dtos.PortfolioComponent;

namespace StockPortfolioApp.Services.PortfolioComponentService
{
    public class PortfolioComponentService : IPortfolioComponentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PortfolioComponentService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetPortfolioComponentDto>>> AddPortfolioComponent(AddPortfolioComponentDto portfolioComponent)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioComponentDto>>();
            _context.PortfolioComponents.Add(_mapper.Map<PortfolioComponent>(portfolioComponent));
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.PortfolioComponents.Select(portfolioComponent =>  _mapper.Map<GetPortfolioComponentDto>(portfolioComponent)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioComponentDto>>> DeletePortfolioComponent(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioComponentDto>>();
            try
            {
                var portfolioComponent = await _context.PortfolioComponents.FirstOrDefaultAsync(x => x.Id == id);

                if (portfolioComponent == null)
                    throw new Exception($"Portfolio component with Id '{id}' not found.");

                _context.PortfolioComponents.Remove(portfolioComponent);

                serviceResponse.Data = await _context.PortfolioComponents.Select(portfolioComponent => _mapper.Map<GetPortfolioComponentDto>(portfolioComponent)).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioComponentDto>>> GetAllPortfolioComponents()
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioComponentDto>>();
            var portfolioComponents = await _context.PortfolioComponents.ToListAsync();
            serviceResponse.Data = portfolioComponents.Select(portfolioComponent => _mapper.Map<GetPortfolioComponentDto>(portfolioComponent)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPortfolioComponentDto>> GetSinglePortfolioComponent(int id)
        {
            var serviceResponse = new ServiceResponse<GetPortfolioComponentDto>();
            try
            {
                var portfolioComponent = await _context.PortfolioComponents.FirstOrDefaultAsync(x => x.Id == id);

                if (portfolioComponent == null)
                    throw new Exception($"Portfolio component with Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetPortfolioComponentDto>(portfolioComponent);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioComponentDto>>> UpdatePortfolioComponent(int id, AddPortfolioComponentDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioComponentDto>>();
            try
            { 
                var portfolioComponent = await _context.PortfolioComponents.FirstOrDefaultAsync(x => x.Id == id);

                if (portfolioComponent == null)
                    throw new Exception($"Portfolio component with Id '{id}' not found.");

                portfolioComponent.PortfolioId = request.PortfolioId;
                portfolioComponent.StockId = request.StockId;
                portfolioComponent.Value = request.Value;
                portfolioComponent.Amount = request.Amount;

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.PortfolioComponents.Select(portfolioComponent => _mapper.Map<GetPortfolioComponentDto>(portfolioComponent)).ToListAsync();
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
