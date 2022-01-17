using System;
using System.Threading.Tasks;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public interface IOperationRepository
    {
        Task Add(Operation operation);
        Task Update(Operation operation);
        Task<Operation> Get(Guid id);
        Task Delete(Operation operation);
    }
}