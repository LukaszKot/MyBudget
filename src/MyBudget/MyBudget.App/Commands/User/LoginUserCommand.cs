using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.User
{
    public record LoginUserCommand(
        [Required(ErrorMessage = "Login jest wymagany!")] 
        string Username, 
        [Required(ErrorMessage = "Hasło jest wymagane!")] 
        string Password);
}