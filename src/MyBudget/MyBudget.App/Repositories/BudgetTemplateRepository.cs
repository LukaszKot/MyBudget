using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBudget.App.Database;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public class BudgetTemplateRepository : IBudgetTemplateRepository
    {
        private readonly AppDbContext _dbContext;
        public BudgetTemplateRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BudgetTemplate> GetBudgetTemplateWithOperationTemplates(Guid budgetId)
        {
            return await _dbContext.BudgetTemplates.Include(x => x.OperationTemplates)
                .SingleOrDefaultAsync(x => x.Id == budgetId);
        }
    }
}