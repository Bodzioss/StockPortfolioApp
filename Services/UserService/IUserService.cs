using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Dtos.User;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<GetUserDto>> GetSingleUser(int id);
        Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto user);
        Task<ServiceResponse<List<GetUserDto>>> UpdateUser(int id, AddUserDto request);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
    }
}
