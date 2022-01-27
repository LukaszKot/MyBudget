using System.Collections.Generic;
using MyBudget.App.DTO.Budget;

namespace MyBudget.App.Queries.OperationTemplates
{
    public class GetOperationTemplatesQueryResponse
    {
        public IEnumerable<OperationTemplateDto> OperationTemplates { get; set; }
    }
}