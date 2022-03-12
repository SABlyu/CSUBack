using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet] // READ
        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }

        [HttpPost] // CREATE
        public IActionResult AddUser([FromBody] User user)
        {
            _userService.AddUser(user);
            return Ok(); //Created();
        }


    }
}
