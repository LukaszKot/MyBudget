using System.ComponentModel.DataAnnotations;

namespace MyBudget.Infrastructure.Commands.User;

public record RegisterUserCommand(
    [Required] string Username, 
    [Required] string Password, 
    [Required] string RepeatPassword);