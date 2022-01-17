using System.Threading.Tasks;
using MyBudget.App.Commands.OperationTemplate;
using MyBudget.App.Domain;
using MyBudget.App.Repositories;

namespace MyBudget.App.Services
{
    public class OperationTemplateService : IOperationTemplateService
    {
        private readonly IOperationTemplateRepository _operationTemplateRepository;

        public OperationTemplateService(IOperationTemplateRepository operationTemplateRepository)
        {
            _operationTemplateRepository = operationTemplateRepository;
        }

        public async Task CreateOperationTemplateAsync(CreateOperationTemplateCommand command)
        {
            var operationTemplate = new OperationTemplate(command.UserId, command.Name, command.DefaultValue,
                command.ValueType, command.BudgetTemplateId, command.OperationCategoryId);
            await _operationTemplateRepository.Create(operationTemplate);
        }

        public async Task UpdateOperationTemplateAsync(UpdateOperationTemplateCommand command)
        {
            var operationTemplate = await _operationTemplateRepository.GetAsync(command.Id);
            operationTemplate.SetName(command.Name);
            operationTemplate.SetValue(command.DefaultValue, command.ValueType);
            operationTemplate.OperationCategoryId = command.OperationCategoryId;
            await _operationTemplateRepository.Update(operationTemplate);
        }

        public async Task DeleteOperationTemplateAsync(DeleteOperationTemplateCommand command)
        {
            var operationTemplate = await _operationTemplateRepository.GetAsync(command.Id);
            await _operationTemplateRepository.Delete(operationTemplate);
        }
    }
}