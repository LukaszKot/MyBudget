using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Infrastructure.Commands.User;
using MyBudget.Infrastructure.Services;

namespace MyBudget.App.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
    
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterUserCommand registerUserCommand)
        {
            await _userService.RegisterAsync(registerUserCommand);
            return View("RegisterResult");
        }
        
        [HttpGet("register")]
        public IActionResult RegisterForm()
        {
            return View("Register");
        }
    }
}

