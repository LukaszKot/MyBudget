using System;
using System.Collections.Generic;
using MyBudget.App.DTO.Budget;

namespace MyBudget.App.Queries.BudgetTemplate
{
    public record GetBudgetTemplateOperationsQueryResponse(Guid Id, 
        string Name,
        IEnumerable<OperationTemplateDto> OperationTemplates);
}