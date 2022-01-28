using System.Linq;
using System.Threading.Tasks;
using MyBudget.App.Commands.OperationTemplate;
using MyBudget.App.Domain;
using MyBudget.App.DTO.Budget;
using MyBudget.App.Exceptions;
using MyBudget.App.Queries.OperationTemplates;
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
            var operationTemplate = new OperationTemplate(command.UserId!.Value, command.Name, command.DefaultValue,
                command.ValueType, command.BudgetTemplateId, command.OperationCategoryId);
            await _operationTemplateRepository.Create(operationTemplate);
        }

        public async Task UpdateOperationTemplateAsync(UpdateOperationTemplateCommand command)
        {
            var operationTemplate = await _operationTemplateRepository.GetAsync(command.Id, command.UserId!.Value);
            if (operationTemplate is null)
            {
                throw new DomainException(DomainError.ObjectDoesNotExistsOrYouDoNotHaveEnoughPermissions);
            }
            operationTemplate.SetName(command.Name);
            operationTemplate.SetValue(command.DefaultValue, command.ValueType);
            operationTemplate.OperationCategoryId = command.OperationCategoryId;
            await _operationTemplateRepository.Update(operationTemplate);
        }

        public async Task DeleteOperationTemplateAsync(DeleteOperationTemplateCommand command)
        {
            var operationTemplate = await _operationTemplateRepository.GetAsync(command.Id, command.UserId!.Value);
            await _operationTemplateRepository.Delete(operationTemplate);
        }

        public async Task<GetOperationTemplatesQueryResponse> GetOperationTemplates(GetOperationTemplatesQuery query)
        {
            var operationTemplates =
                await _operationTemplateRepository.GetOperationTemplatesAsync(query.UserId!.Value, query.SearchText);
            return new()
            {
                OperationTemplates = operationTemplates.Select(x => new OperationTemplateDto(x.Id, x.Name,
                    x.DefaultValue, x.ValueType, x.BudgetTemplateId, x.OperationCategoryId, x.OperationCategory?.Name))
            };
        }
    }
}