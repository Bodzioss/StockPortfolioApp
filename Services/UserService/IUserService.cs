using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetAllUsers();
        Task<ServiceResponse<User>> GetSingleUser(int id);
        Task<ServiceResponse<List<User>>> AddUser(User user);
        Task<ServiceResponse<List<User>>> UpdateUser(int id, User request);
        Task<ServiceResponse<List<User>>> DeleteUser(int id);
    }
}
