using MyBudget.App.Database;

namespace MyBudget.App.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly AppDbContext _dbContext;
        public OperationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}