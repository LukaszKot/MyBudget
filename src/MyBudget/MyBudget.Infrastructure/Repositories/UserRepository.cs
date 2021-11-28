using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBudget.Core.Domain;
using MyBudget.Infrastructure.Database;

namespace MyBudget.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;
    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task AddAsync(User user)
    {
        await _appDbContext.AddAsync(user);
    }

    public async Task<User?> Get(string username)
    {
        return await _appDbContext.Users.SingleOrDefaultAsync(x => x.Username == username);
    }
}