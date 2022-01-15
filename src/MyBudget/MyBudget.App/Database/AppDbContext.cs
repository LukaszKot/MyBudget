using Microsoft.EntityFrameworkCore;
using MyBudget.App.Domain;

namespace MyBudget.App.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}

