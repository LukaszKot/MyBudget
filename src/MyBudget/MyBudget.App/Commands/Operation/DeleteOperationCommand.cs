using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.Operation
{
    public record DeleteOperationCommand(
        [Required] Guid Id);
}