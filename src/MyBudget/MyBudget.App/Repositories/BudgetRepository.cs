using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBudget.App.Database;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly AppDbContext _dbContext;
        public BudgetRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BudgetTemplate>> GetAllUserBudgetsWithRelatedTables(Guid userId)
        {
            return await _dbContext.BudgetTemplates
                .Where(x => x.UserId == userId)
                .Include(x => x.Budgets)
                .ToListAsync();
        }

        public async Task<Budget> GetBudgetOperations(Guid budgetId)
        {
            return await _dbContext.Budgets
                .Include(x =>x.BudgetTemplate)
                .Include(x => x.Operations)
                .ThenInclude(x => x.OperationCategory)
                .SingleOrDefaultAsync(x => x.Id == budgetId);
        }

        public async Task<Budget> GetBudget(Guid budgetId)
        {
            return await _dbContext.Budgets.SingleOrDefaultAsync(x => x.Id == budgetId);
        }

        public async Task Update(Budget budget)
        {
            _dbContext.Update(budget);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Add(Budget budget)
        {
            await _dbContext.Budgets.AddAsync(budget);
            await _dbContext.SaveChangesAsync();
        }
    }
}