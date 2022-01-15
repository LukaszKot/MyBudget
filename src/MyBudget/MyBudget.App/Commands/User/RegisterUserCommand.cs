using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.User
{
    public record RegisterUserCommand(
        [Required] string Username, 
        [Required] string Password, 
        [Required] string RepeatPassword);
}

