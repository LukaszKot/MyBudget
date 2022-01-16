using MyBudget.App.Database;

namespace MyBudget.App.Repositories
{
    public class OperationTemplateRepository : IOperationTemplateRepository
    {
        private readonly AppDbContext _dbContext;
        public OperationTemplateRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}