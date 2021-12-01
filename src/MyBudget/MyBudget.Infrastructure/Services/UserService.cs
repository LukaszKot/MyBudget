using System.Threading.Tasks;
using MyBudget.Core.Domain;
using MyBudget.Core.Exceptions;
using MyBudget.Infrastructure.Dto.User;
using MyBudget.Infrastructure.Repositories;

namespace MyBudget.Infrastructure.Services;

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

    public async Task RegisterAsync(RegisterUserDto registerUserDto)
    {
        var user = await _userRepository.Get(registerUserDto.Username);
        if (user is not null)
        {
            throw new DomainException(DomainError.UserWithGivenUsernameAlreadyExists);
        }

        _passwordPolicyEnforcer.Validate(registerUserDto.Username, registerUserDto.Password,
            registerUserDto.RepeatPassword);
        var hash = _hashingService.Hash(registerUserDto.Password);
        user = new User(registerUserDto.Username, hash);
        await _userRepository.AddAsync(user);
    }
}