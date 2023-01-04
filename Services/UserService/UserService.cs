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

        public async Task<ServiceResponse<List<User>>> AddUser(User user)
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            users.Add(user);
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            users.Remove(user);

            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> GetSingleUser(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            serviceResponse.Data = user;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> UpdateUser(int id, User request)
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            serviceResponse.Data = users;
            return serviceResponse;
        }
    }
}
