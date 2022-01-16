using System.Threading.Tasks;
using MyBudget.App.Commands.BudgetTemplate;
using MyBudget.App.Events.Budget;
using MyBudget.App.Queries.BudgetTemplate;

namespace MyBudget.App.Services
{
    public interface IBudgetTemplateService
    {
        Task<BudgetTemplateCreatedEvent> CreateBudgetTemplateAsync(CreateBudgetTemplateCommand command);
        Task UpdateBudgetTemplateAsync(UpdateBudgetTemplateCommand command);
        Task DeleteBudgetTemplateAsync(DeleteBudgetTemplateCommand command);
        Task<GetBudgetTemplateOperationsQueryResponse> GetBudgetTemplateOperationsAsync(
            GetBudgetTemplateOperationsQuery query);
    }
}