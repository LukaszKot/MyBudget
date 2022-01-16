using MyBudget.App.Database;

namespace MyBudget.App.Repositories
{
    public class BudgetTemplateRepository : IBudgetTemplateRepository
    {
        private readonly AppDbContext _dbContext;
        public BudgetTemplateRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}