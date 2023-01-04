using Microsoft.AspNetCore.Mvc;
using StockPortfolioApp.Services.UserService;

namespace StockPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetSingleUser(int id)
        {
            return Ok(await _userService.GetSingleUser(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<User>>>> AddUser(User user)
        {
            return Ok(await _userService.AddUser(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> UpdateUser(int id, User request)
        {
            return Ok(await _userService.UpdateUser(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> DeleteUser(int id)
        {
            return Ok(await _userService.DeleteUser(id));
        }
    }
}
