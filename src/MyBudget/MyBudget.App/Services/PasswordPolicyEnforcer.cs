using System.Text.RegularExpressions;
using MyBudget.App.Domain;
using MyBudget.App.Exceptions;

namespace MyBudget.App.Services
{
    public class PasswordPolicyEnforcer : IPasswordPolicyEnforcer
    {
        private readonly Regex _passwordRegex 
            = new(RegexConsts.Password);
        public void Validate(string username, string password, string repeatedPassword)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new DomainException(DomainError.PasswordHaveToBeProvided);
            }

            if (!password.Equals(repeatedPassword))
            {
                throw new DomainException(DomainError.PasswordsAreNotIdentitcal);
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
}

