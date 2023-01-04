using StockPortfolioApp.Dtos.Transaction;
using StockPortfolioApp.Dtos.User;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User> {
            new User
            {
                Id = 1,
                FirstName = "First Name",
                LastName = "Last Name",
            }
        };
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto user)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            users.Add(_mapper.Map<User>(user));
            serviceResponse.Data = users.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var user = users.Find(x => x.Id == id);

                if (user is null)
                    throw new Exception($"User with Id '{id}' not found.");

                users.Remove(user);

                serviceResponse.Data = users.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
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
            serviceResponse.Data = users.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetSingleUser(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = users.Find(x => x.Id == id);

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
                var user = users.Find(x => x.Id == id);

                if (user is null)
                    throw new Exception($"User with Id '{id}' not found.");

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

                serviceResponse.Data = users.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
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
