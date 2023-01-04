using StockPortfolioApp.Dtos.StockExchange;

namespace StockPortfolioApp.Services.StockExchangeService
{
    public interface IStockExchangeService
    {
        Task<ServiceResponse<List<GetStockExchangeDto>>> GetAllStockExchange();
        Task<ServiceResponse<GetStockExchangeDto>> GetSingleStockExchange(int id);
        Task<ServiceResponse<List<GetStockExchangeDto>>> AddStockExchange(AddStockExchangeDto stockData);
        Task<ServiceResponse<List<GetStockExchangeDto>>> UpdateStockExchange(int id, AddStockExchangeDto request);
        Task<ServiceResponse<List<GetStockExchangeDto>>> DeleteStockExchange(int id);
    }
}
