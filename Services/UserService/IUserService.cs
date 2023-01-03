using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.UserService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetSingleUser(int id);
        List<User> AddUser(User user);
        List<User> UpdateUsera(int id, User request);
        List<User> DeleteUser(int id);
    }
}
