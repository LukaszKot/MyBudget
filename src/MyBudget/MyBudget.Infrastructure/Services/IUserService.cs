using System.Threading.Tasks;
using MyBudget.Infrastructure.Commands.User;

namespace MyBudget.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserCommand registerUserCommand);
    }
}

