using Microsoft.EntityFrameworkCore;
using MyBudget.Core.Domain;

namespace MyBudget.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}