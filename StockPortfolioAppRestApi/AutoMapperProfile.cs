using StockPortfolioApp.Dtos.Portfolio;
using StockPortfolioApp.Dtos.PortfolioComponent;
using StockPortfolioApp.Dtos.Stock;
using StockPortfolioApp.Dtos.StockData;
using StockPortfolioApp.Dtos.StockExchange;
using StockPortfolioApp.Dtos.Transaction;
using StockPortfolioApp.Dtos.User;

namespace StockPortfolioApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PortfolioComponent, GetPortfolioComponentDto>();
            CreateMap<AddPortfolioComponentDto, PortfolioComponent>();
            CreateMap<Portfolio, GetPortfolioDto>();
            CreateMap<AddPortfolioDto, Portfolio>();
            CreateMap<Stock, GetStockDto>();
            CreateMap<AddStockDto, Stock>();
            CreateMap<StockData, GetStockDataDto>();
            CreateMap<AddStockDataDto, StockData>();
            CreateMap<StockExchange, GetStockExchangeDto>();
            CreateMap<AddStockExchangeDto, StockExchange>();
            CreateMap<Transaction, GetTransactionDto>();
            CreateMap<AddTransactionDto, Transaction>();
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}
