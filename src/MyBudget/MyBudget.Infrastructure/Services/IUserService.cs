using System.Threading.Tasks;
using MyBudget.Infrastructure.Dto.User;

namespace MyBudget.Infrastructure.Services;

public interface IUserService
{
    Task RegisterAsync(RegisterUserDto registerUserDto);
}