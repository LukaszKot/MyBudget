using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.BudgetTemplate
{
    public class UpdateBudgetTemplateCommand : CommandWithServiceValidation
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
        
}