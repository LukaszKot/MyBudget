using System.Threading.Tasks;
using MyBudget.App.Commands.Operation;
using MyBudget.App.Domain;
using MyBudget.App.Repositories;

namespace MyBudget.App.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IOperationTemplateRepository _operationTemplateRepository;

        public OperationService(IOperationRepository operationRepository, IOperationTemplateRepository operationTemplateRepository)
        {
            _operationRepository = operationRepository;
            _operationTemplateRepository = operationTemplateRepository;
        }

        public async Task CreateOperationAsync(CreateOperationCommand command)
        {
            var operation = new Operation(command.BudgetId!.Value, command.Name, command.DefaultValue, command.ValueType,
                command.Date, command.OperationCategoryId);
            await _operationRepository.Add(operation);
        }

        public async Task UpdateOperationAsync(UpdateOperationCommand command)
        {
            var operation = await _operationRepository.Get(command.Id!.Value);
            operation.SetName(command.Name);
            operation.SetValue(command.DefaultValue, command.ValueType);
            operation.SetDate(command.Date);
            operation.OperationCategoryId = command.OperationCategoryId;
            await _operationRepository.Update(operation);
        }

        public async Task DeleteOperationAsync(DeleteOperationCommand command)
        {
            var operation = await _operationRepository.Get(command.Id);
            await _operationRepository.Delete(operation);
        }

        public async Task CreateOperationFromTemplateAsync(CreateOperationFromTemplateCommand command)
        {
            var operationTemplate = await _operationTemplateRepository.GetAsync(command.OperationTemplateId);
            var operation = new Operation(command.BudgetId, operationTemplate);
            await _operationRepository.Add(operation);
        }
    }
}