using StockPortfolioApp.Dtos.PortfolioComponent;

namespace StockPortfolioApp.Services.PortfolioComponentService
{
    public class PortfolioComponentService : IPortfolioComponentService
    {
        public static List<PortfolioComponent> portfolioComponents = new List<PortfolioComponent>{
                new PortfolioComponent
                {
                    Id = 1,
                    PortfolioId = 1,
                    StockId = 1,
                    Value = 195,
                    Amount = 1
                }
        };
        private readonly IMapper _mapper;

        public PortfolioComponentService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetPortfolioComponentDto>>> AddPortfolioComponent(AddPortfolioComponentDto portfolioComponent)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioComponentDto>>();
            portfolioComponents.Add(_mapper.Map<PortfolioComponent>(portfolioComponent));
            serviceResponse.Data = portfolioComponents.Select(portfolioComponent =>  _mapper.Map<GetPortfolioComponentDto>(portfolioComponent)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPortfolioComponentDto>>> DeletePortfolioComponent(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPortfolioComponentDto>>();
            try
            {
                var portfolioComponent = portfolioComponents.FirstOrDefault(x => x.Id == id);

                if (portfolioComponent == null)
                    throw new Exception($"Portfolio component with Id '{id}' not found.");

                portfolioComponents.Remove(portfolioComponent);

                serviceResponse.Data = portfolioComponents.Select(portfolioComponent => _mapper.Map<GetPortfolioComponentDto>(portfolioComponent)).ToList();
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
            serviceResponse.Data = portfolioComponents.Select(portfolioComponent => _mapper.Map<GetPortfolioComponentDto>(portfolioComponent)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPortfolioComponentDto>> GetSinglePortfolioComponent(int id)
        {
            var serviceResponse = new ServiceResponse<GetPortfolioComponentDto>();
            try
            {
                var portfolioComponent = portfolioComponents.FirstOrDefault(x => x.Id == id);

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
                var portfolioComponent = portfolioComponents.FirstOrDefault(x => x.Id == id);

                if (portfolioComponent == null)
                    throw new Exception($"Portfolio component with Id '{id}' not found.");

                portfolioComponent.PortfolioId = request.PortfolioId;
                portfolioComponent.StockId = request.StockId;
                portfolioComponent.Value = request.Value;
                portfolioComponent.Amount = request.Amount;

                serviceResponse.Data = portfolioComponents.Select(portfolioComponent => _mapper.Map<GetPortfolioComponentDto>(portfolioComponent)).ToList();
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
