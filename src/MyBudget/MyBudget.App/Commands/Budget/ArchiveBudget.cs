using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.Budget
{
    public record ArchiveBudget([Required] Guid Id);
}