using StockPortfolioApp.Dtos.Stock;
using StockPortfolioApp.Dtos.Transaction;

namespace StockPortfolioApp.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TransactionService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto transaction)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            _context.Transactions.Add(_mapper.Map<Transaction>(transaction));
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Transactions.Select(transaction => _mapper.Map<GetTransactionDto>(transaction)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);

                if (transaction is null)
                    throw new Exception($"Transaction with Id '{id}' not found.");

                _context.Transactions.Remove(transaction);
                serviceResponse.Data = await _context.Transactions.Select(transaction => _mapper.Map<GetTransactionDto>(transaction)).ToListAsync();
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
            serviceResponse.Data = await _context.Transactions.Select(transaction => _mapper.Map<GetTransactionDto>(transaction)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransactionDto>> GetSingleTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();
            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);

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
                var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);

                if (transaction is null)
                    throw new Exception($"Transaction with Id '{id}' not found.");

                transaction.StockId = request.StockId;
                transaction.PortfolioId = request.PortfolioId;
                transaction.Value = request.Value;
                transaction.Amount = request.Amount;

                serviceResponse.Data = await _context.Transactions.Select(transaction => _mapper.Map<GetTransactionDto>(transaction)).ToListAsync();
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
