using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.User;
using MyBudget.App.Services;

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

        [HttpGet("login")]
        public IActionResult LoginForm()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUserCommand loginUserCommand)
        {
            await _userService.LoginAsync(loginUserCommand);
            return Redirect("/");
        }
        
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return Redirect("/user/login");
        }
    }
}

