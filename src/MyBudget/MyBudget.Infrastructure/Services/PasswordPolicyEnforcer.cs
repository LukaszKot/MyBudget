using System.Text.RegularExpressions;
using MyBudget.Core.Exceptions;

namespace MyBudget.Infrastructure.Services;

public class PasswordPolicyEnforcer : IPasswordPolicyEnforcer
{
    private readonly Regex _passwordRegex 
        = new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
    public void Validate(string username, string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new DomainException(DomainError.PasswordHaveToBeProvided);
        }
        
        if (username.Contains(password) || password.Contains(username))
        {
            throw new DomainException(DomainError.PasswordCannotBePartOfUsername);
        }

        if (!_passwordRegex.IsMatch(password))
        {
            throw new DomainException(DomainError.PasswordPolicyVaildationFailed);
        }
    }
}