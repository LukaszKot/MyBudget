using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<OperationCategory>> GetAll(Guid userId, string searchText="");
        Task Create(OperationCategory operationCategory);
        Task<OperationCategory> Get(Guid id);
        Task Update(OperationCategory operationCategory);
        Task Delete(OperationCategory operationCategory);
    }
}