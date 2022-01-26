using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public interface IBudgetTemplateRepository
    {
        Task<IEnumerable<BudgetTemplate>> GetBudgetTemplates(Guid userId);
        Task<BudgetTemplate> GetBudgetTemplateWithOperationTemplates(Guid budgetId);
        Task Create(BudgetTemplate budgetTemplate);
        Task Update(BudgetTemplate budgetTemplate);
        Task<BudgetTemplate> Get(Guid id);
        Task Delete(BudgetTemplate budgetTemplate);
    }
}