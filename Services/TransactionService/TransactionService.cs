using StockPortfolioApp.Dtos.Stock;
using StockPortfolioApp.Dtos.Transaction;

namespace StockPortfolioApp.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private static List<Transaction> transactions = new List<Transaction> {
            new Transaction
            {
                Id = 1,
                StockId = 1,
                PortfolioId = 1,
                Value = 1,
                Amount = 1
            }
        };
        private readonly IMapper _mapper;

        public TransactionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto transaction)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            transactions.Add(_mapper.Map<Transaction>(transaction));
            serviceResponse.Data = transactions.Select(transaction => _mapper.Map<GetTransactionDto>(transaction)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            try
            {
                var transaction = transactions.Find(x => x.Id == id);

                if (transaction is null)
                    throw new Exception($"Transaction with Id '{id}' not found.");

                transactions.Remove(transaction);
                serviceResponse.Data = transactions.Select(transaction => _mapper.Map<GetTransactionDto>(transaction)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransactions()
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            serviceResponse.Data = transactions.Select(transaction => _mapper.Map<GetTransactionDto>(transaction)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransactionDto>> GetSingleTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();
            try
            {
                var transaction = transactions.Find(x => x.Id == id);

                if (transaction is null)
                    throw new Exception($"Transaction with Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetTransactionDto>(transaction);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> UpdateTransaction(int id, AddTransactionDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            try
            {
                var transaction = transactions.Find(x => x.Id == id);

                if (transaction is null)
                    throw new Exception($"Transaction with Id '{id}' not found.");

                transaction.StockId = request.StockId;
                transaction.PortfolioId = request.PortfolioId;
                transaction.Value = request.Value;
                transaction.Amount = request.Amount;

                serviceResponse.Data = transactions.Select(transaction => _mapper.Map<GetTransactionDto>(transaction)).ToList();
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
