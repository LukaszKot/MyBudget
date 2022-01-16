using System.Threading.Tasks;
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

        public UserService(IUserRepository userRepository, 
            IHashingService hashingService,
            IPasswordPolicyEnforcer passwordPolicyEnforcer)
        {
            _userRepository = userRepository;
            _hashingService = hashingService;
            _passwordPolicyEnforcer = passwordPolicyEnforcer;
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

        public Task LoginAsync(LoginUserCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}

