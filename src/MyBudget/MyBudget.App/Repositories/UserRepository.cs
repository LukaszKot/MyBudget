using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBudget.App.Database;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(User user)
        {
            _appDbContext.Add(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User?> Get(string username)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(x => x.Username == username);
        }
    }
}

