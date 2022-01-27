using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<BudgetTemplate>> GetBudgetTemplates(Guid userId)
        {
            return await _dbContext.BudgetTemplates
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<BudgetTemplate> GetBudgetTemplateWithOperationTemplates(Guid budgetId)
        {
            return await _dbContext.BudgetTemplates
                .Include(x => x.OperationTemplates)
                .ThenInclude(x => x.OperationCategory)
                .SingleOrDefaultAsync(x => x.Id == budgetId);
        }

        public async Task Create(BudgetTemplate budgetTemplate)
        {
            await _dbContext.AddAsync(budgetTemplate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(BudgetTemplate budgetTemplate)
        {
            _dbContext.Update(budgetTemplate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<BudgetTemplate> Get(Guid id)
        {
            return await _dbContext.BudgetTemplates.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(BudgetTemplate budgetTemplate)
        {
            _dbContext.BudgetTemplates.Remove(budgetTemplate);
            await _dbContext.SaveChangesAsync();
        }
    }
}