using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = new List<User>()
            {
                new User
                {
                    Id = 1,
                    FirstName = "First Name",
                    LastName = "Last Name",
                }
            };
            return Ok(userList);
        }
    }
}
