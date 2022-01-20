using System.ComponentModel.DataAnnotations;
using MyBudget.App.Domain;

namespace MyBudget.App.Commands.User
{
    public record RegisterUserCommand(
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [RegularExpression(RegexConsts.Username, ErrorMessage = "Login nie spełnia wymagań!")]
        string Username, 
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [RegularExpression(RegexConsts.Password, ErrorMessage = "Hasło nie zawiera dużej lister, małej litery, cyfry lub znaku specjalnego!")]
        string Password, 
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [RegularExpression(RegexConsts.Password, ErrorMessage = "Hasło nie zawiera dużej lister, małej litery, cyfry lub znaku specjalnego!")]
        string RepeatPassword);
}

