using System.Threading.Tasks;
using MyBudget.App.Commands.Operation;

namespace MyBudget.App.Services
{
    public interface IOperationService
    {
        Task CreateOperationAsync(CreateOperationCommand command);
        Task UpdateOperationAsync(UpdateOperationCommand command);
        Task DeleteOperationAsync(DeleteOperationCommand command);
        Task CreateOperationFromTemplateAsync(CreateOperationFromTemplateCommand command);
    }
}