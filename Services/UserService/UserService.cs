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

        public List<User> AddUser(User user)
        {
            users.Add(user);
            return users;
        }

        public List<User> DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            users.Remove(user);

            return users;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetSingleUser(int id)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            return user;
        }

        public List<User> UpdateUser(int id, User request)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            return users;
        }
    }
}
