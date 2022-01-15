using System.Threading.Tasks;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> Get(string username);
    }
}

