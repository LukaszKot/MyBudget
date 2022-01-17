using System.Collections.Generic;
using MyBudget.App.DTO.Budget;

namespace MyBudget.App.Queries.Budget
{
    public record GetBudgetsQueryResponse(
        IEnumerable<BudgetTemplateDto> BudgetTemplates,
        IEnumerable<BudgetDto> ActiveBudgets, 
        IEnumerable<BudgetDto> ArchivedBudgets,
        IEnumerable<OperationTemplateDto> OperationTemplates,
        IEnumerable<CategoryDto> Categories);
}