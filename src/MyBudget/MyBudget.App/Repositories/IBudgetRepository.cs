using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public interface IBudgetRepository
    {
        Task<IEnumerable<BudgetTemplate>> GetAllUserBudgetsWithRelatedTables(Guid userId);
        Task<Budget> GetBudgetOperations(Guid budgetId);
        Task<Budget> GetBudget(Guid budgetId);
        Task Update(Budget budget);
        Task Add(Budget budget);
    }
}