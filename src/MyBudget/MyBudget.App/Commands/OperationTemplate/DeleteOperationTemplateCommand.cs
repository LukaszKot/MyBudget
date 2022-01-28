using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.OperationTemplate
{
    public class DeleteOperationTemplateCommand : CommandWithServiceValidation
    {
        public Guid Id { get; set; }
        public Guid BudgetTemplateId { get; set; }
        public Guid? UserId { get; set; }
    }
}