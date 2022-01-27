using System;

namespace MyBudget.App.Queries.OperationTemplates
{
    public class GetOperationTemplatesQuery
    {
        public Guid? UserId { get; set; }
        public string SearchText { get; set; }
    }
}