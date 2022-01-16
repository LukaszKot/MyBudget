using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.Budget
{
    public record ArchiveBudgetCommand([Required] Guid Id);
}