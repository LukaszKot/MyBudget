namespace MyBudget.Core.Exceptions
{
    public enum DomainError
    {
        InvalidUsername,
        UserWithGivenUsernameAlreadyExists,
        PasswordCannotBePartOfUsername,
        PasswordHaveToBeProvided,
        PasswordPolicyVaildationFailed,
        PasswordsAreNotIdentitcal
    }
}