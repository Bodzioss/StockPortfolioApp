using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Models;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User> { 
            new User
            {
                Id = 1,
                FirstName = "First Name",
                LastName = "Last Name",
            }
        };
        

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser(int id)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return NotFound("Sorry, but this StockData does not exist.");

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsera(int id, User request)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return NotFound("Sorry, but this StockData does not exist.");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, User request)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return NotFound("Sorry, but this StockData does not exist.");

            users.Remove(user);

            return Ok(users);
        }
    }
}
