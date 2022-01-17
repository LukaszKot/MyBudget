using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.User;
using MyBudget.App.Domain;
using MyBudget.App.Exceptions;
using MyBudget.App.Repositories;

namespace MyBudget.App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashingService _hashingService;
        private readonly IPasswordPolicyEnforcer _passwordPolicyEnforcer;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, 
            IHashingService hashingService,
            IPasswordPolicyEnforcer passwordPolicyEnforcer, 
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _hashingService = hashingService;
            _passwordPolicyEnforcer = passwordPolicyEnforcer;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task RegisterAsync(RegisterUserCommand registerUserCommand)
        {
            var user = await _userRepository.Get(registerUserCommand.Username);
            if (user is not null)
            {
                throw new DomainException(DomainError.UserWithGivenUsernameAlreadyExists);
            }

            _passwordPolicyEnforcer.Validate(registerUserCommand.Username, registerUserCommand.Password,
                registerUserCommand.RepeatPassword);
            var hash = _hashingService.Hash(registerUserCommand.Password);
            user = new User(registerUserCommand.Username, hash);
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(LoginUserCommand command)
        {
            var user = await _userRepository.Get(command.Username);
            if (user is null)
            {
                throw new DomainException(DomainError.InvalidCredentials);
            }

            if (!_hashingService.CheckPassword(user.Hash, command.Password))
            {
                throw new DomainException(DomainError.InvalidCredentials);
            }
            await Login(user);
        }
        
        public async Task LogoutAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            await httpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private async Task Login(User user)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Username)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);

            var httpContext = _httpContextAccessor.HttpContext;
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties {IsPersistent = false});
        }
    }
}

