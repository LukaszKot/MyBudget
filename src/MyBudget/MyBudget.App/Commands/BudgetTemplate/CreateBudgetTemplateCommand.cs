using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.BudgetTemplate
{
    public record CreateBudgetTemplateCommand(
        [Required] string Name)
    {
        public Guid UserId { get; set; }
    }
}