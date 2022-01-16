using System.Threading.Tasks;
using MyBudget.App.Commands.User;

namespace MyBudget.App.Services
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserCommand registerUserCommand);
        Task LoginAsync(LoginUserCommand command);
    }
}

