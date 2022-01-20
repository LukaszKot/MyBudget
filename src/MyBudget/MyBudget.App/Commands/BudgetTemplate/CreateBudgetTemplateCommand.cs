using System;

namespace MyBudget.App.Commands.BudgetTemplate
{
    public class CreateBudgetTemplateCommand : CommandWithServiceValidation
    {
        public string? Name { get; set; }
        public Guid? UserId { get; set; }
    }
}