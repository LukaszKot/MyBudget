using System;
using System.Threading.Tasks;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public interface IBudgetTemplateRepository
    {
        Task<BudgetTemplate> GetBudgetTemplateWithOperationTemplates(Guid budgetId);
        Task Create(BudgetTemplate budgetTemplate);
        Task Update(BudgetTemplate budgetTemplate);
        Task<BudgetTemplate> Get(Guid id);
        Task Delete(BudgetTemplate budgetTemplate);
    }
}