namespace MyBudget.Infrastructure.Services
{
    public interface IPasswordPolicyEnforcer
    {
        void Validate(string username, string password, string repeatedPassword);
    }
}

