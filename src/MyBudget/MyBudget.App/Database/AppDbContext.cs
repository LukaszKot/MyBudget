using Microsoft.EntityFrameworkCore;
using MyBudget.App.Domain;

namespace MyBudget.App.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetTemplate> BudgetTemplates { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationCategory> OperationCategories { get; set; }
        public DbSet<OperationTemplate> OperationTemplates { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationTemplate>()
                .HasOne(x => x.BudgetTemplate)
                .WithMany(x => x.OperationTemplates)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Operation>()
                .HasOne(x => x.OperationTemplate)
                .WithMany(x => x.Operations)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

