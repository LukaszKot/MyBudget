using System;
using System.Threading.Tasks;
using MyBudget.App.Commands.Budget;
using MyBudget.App.Events.Budget;
using MyBudget.App.Queries.Budget;

namespace MyBudget.App.Services
{
    public interface IBudgetService
    {
        Task<GetBudgetsQueryResponse> GetBudgetsAsync(Guid userId);
        Task<GetBudgetOperationsQueryResponse> GetBudgetOperationsAsync(GetBudgetOperationsQuery query);
        Task<BudgetCreatedEvent> ArchiveBudgetAsync(ArchiveBudgetCommand command);
        Task<BudgetCreatedEvent> CreateBudgetAsync(CreateBudgetCommand command);
        Task<GetArchivedBudgetOperationsQueryResponse> GetArchivedBudgetAsync(GetBudgetOperationsQuery query);
    }
}