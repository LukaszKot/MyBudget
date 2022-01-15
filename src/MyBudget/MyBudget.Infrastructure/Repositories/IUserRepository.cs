using System.Threading.Tasks;
using MyBudget.Core.Domain;

namespace MyBudget.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> Get(string username);
    }
}

