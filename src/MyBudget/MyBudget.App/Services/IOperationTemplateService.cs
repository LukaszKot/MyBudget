using System.Threading.Tasks;
using MyBudget.App.Commands.OperationTemplate;

namespace MyBudget.App.Services
{
    public interface IOperationTemplateService
    {
        Task CreateOperationTemplateAsync(CreateOperationTemplateCommand command);
        Task UpdateOperationTemplateAsync(UpdateOperationTemplateCommand command);
        Task DeleteOperationTemplateAsync(DeleteOperationTemplateCommand command);
    }
}