using MyBudget.App.Database;

namespace MyBudget.App.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly AppDbContext _dbContext;
        public BudgetRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}