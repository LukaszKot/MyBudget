using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public interface IOperationTemplateRepository
    {
        Task<IEnumerable<OperationTemplate>> GetOperationTemplatesAsync(Guid userId, string? searchText=null);
        Task<OperationTemplate?> GetAsync(Guid id, Guid userId);
        Task Create(OperationTemplate operationTemplate);
        Task Update(OperationTemplate operationTemplate);
        Task Delete(OperationTemplate operationTemplate);
    }
}