using StockPortfolioApp.Dtos.Transaction;
using StockPortfolioApp.Dtos.User;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto user)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            _context.Users.Add(_mapper.Map<User>(user));
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Users.Select(user => _mapper.Map<GetUserDto>(user)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user is null)
                    throw new Exception($"User with Id '{id}' not found.");

                _context.Users.Remove(user);

                serviceResponse.Data = await _context.Users.Select(user => _mapper.Map<GetUserDto>(user)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            serviceResponse.Data = await _context.Users.Select(user => _mapper.Map<GetUserDto>(user)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetSingleUser(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user is null)
                    throw new Exception($"User with Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> UpdateUser(int id, AddUserDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user is null)
                    throw new Exception($"User with Id '{id}' not found.");

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

                serviceResponse.Data = await _context.Users.Select(user => _mapper.Map<GetUserDto>(user)).ToListAsync();
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
