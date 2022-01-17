namespace MyBudget.App.Services
{
    public interface IHashingService
    {
        string Hash(string password);
        bool CheckPassword(string hash, string password);
    }
}

