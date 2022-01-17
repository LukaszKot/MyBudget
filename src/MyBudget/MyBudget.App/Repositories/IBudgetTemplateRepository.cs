using System;
using System.Threading.Tasks;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public interface IBudgetTemplateRepository
    {
        Task<BudgetTemplate> GetBudgetTemplateWithOperationTemplates(Guid budgetId);
    }
}