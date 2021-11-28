namespace MyBudget.Infrastructure.Services;

public interface IHashingService
{
    string Hash(string password);
}