using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.User
{
    public record LoginUserCommand(
        [Required] string Username, 
        [Required] string Password);
}