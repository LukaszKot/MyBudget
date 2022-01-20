namespace MyBudget.App.Exceptions
{
    public enum DomainError
    {
        InvalidUsername,
        UserWithGivenUsernameAlreadyExists,
        PasswordCannotBePartOfUsername,
        PasswordHaveToBeProvided,
        PasswordPolicyVaildationFailed,
        PasswordsAreNotIdentitcal,
        InvalidObjectName,
        InvalidOperationValue,
        CannotRenameOperationIfInheritsFromTemplate,
        InvalidCredentials,
        InvalidDate
    }
}