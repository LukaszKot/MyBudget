namespace MyBudget.App.Services
{
    public interface IPasswordPolicyEnforcer
    {
        void Validate(string username, string password, string repeatedPassword);
    }
}

