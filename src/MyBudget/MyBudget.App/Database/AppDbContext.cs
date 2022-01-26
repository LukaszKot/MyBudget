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
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Operation>()
                .HasOne(x => x.OperationTemplate)
                .WithMany(x => x.Operations)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BudgetTemplate>()
                .HasMany(x => x.Budgets)
                .WithOne(x => x.BudgetTemplate)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Budget>()
                .HasMany(x => x.Operations)
                .WithOne(x => x.Budget)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<User>()
                .HasMany(x=> x.OperationCategories)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasMany(x => x.BudgetTemplates)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasMany(x => x.OperationTemplates)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasMany(x => x.Budgets)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<OperationCategory>()
                .HasMany(x => x.Operations)
                .WithOne(x => x.OperationCategory)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<OperationCategory>()
                .HasMany(x => x.OperationTemplates)
                .WithOne(x => x.OperationCategory)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<BudgetTemplate>()
                .Property(x => x.Name)
                .HasMaxLength(50);
            modelBuilder.Entity<Operation>(x =>
            {
                x.Property(y => y.Name)
                    .HasMaxLength(50);
                x.Property(y => y.Value)
                    .HasPrecision(18, 2);
            });
            modelBuilder.Entity<OperationCategory>()
                .Property(x => x.Name)
                .HasMaxLength(50);
            modelBuilder.Entity<OperationTemplate>(x =>
            {
                x.Property(y => y.Name)
                    .HasMaxLength(50);
                x.Property(y => y.DefaultValue)
                    .HasPrecision(18, 2);
            });
            modelBuilder.Entity<User>(x =>
                {
                    x.Property(y => y.Username)
                        .HasMaxLength(50);
                    x.Property(y => y.Hash)
                        .HasMaxLength(1024);
                });
        }
    }
}

