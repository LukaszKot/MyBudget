using System.Linq;
using System.Threading.Tasks;
using MyBudget.App.Commands.BudgetTemplate;
using MyBudget.App.Domain;
using MyBudget.App.DTO.Budget;
using MyBudget.App.Events.Budget;
using MyBudget.App.Queries.BudgetTemplate;
using MyBudget.App.Repositories;

namespace MyBudget.App.Services
{
    public class BudgetTemplateService : IBudgetTemplateService
    {
        private readonly IBudgetTemplateRepository _budgetTemplateRepository;

        public BudgetTemplateService(IBudgetTemplateRepository budgetTemplateRepository)
        {
            _budgetTemplateRepository = budgetTemplateRepository;
        }

        public async Task<BudgetTemplateCreatedEvent> CreateBudgetTemplateAsync(CreateBudgetTemplateCommand command)
        {
            var budgetTemplate = new BudgetTemplate(command.UserId!.Value, command.Name!);
            await _budgetTemplateRepository.Create(budgetTemplate);
            return new BudgetTemplateCreatedEvent(budgetTemplate.Id);
        }

        public async Task UpdateBudgetTemplateAsync(UpdateBudgetTemplateCommand command)
        {
            var budgetTemplate = await _budgetTemplateRepository.Get(command.Id!.Value);
            budgetTemplate.SetName(command.Name!);
            await _budgetTemplateRepository.Update(budgetTemplate);
        }

        public async Task DeleteBudgetTemplateAsync(DeleteBudgetTemplateCommand command)
        {
            var budgetTemplate = await _budgetTemplateRepository.Get(command.Id);
            await _budgetTemplateRepository.Delete(budgetTemplate);
        }

        public async Task<GetBudgetTemplateOperationsQueryResponse> GetBudgetTemplateOperationsAsync(GetBudgetTemplateOperationsQuery query)
        {
            var budgetTemplates = await _budgetTemplateRepository.GetBudgetTemplateWithOperationTemplates(query.Id);
            return new(budgetTemplates.Id,
                budgetTemplates.Name,
                budgetTemplates.OperationTemplates
                    .OrderByDescending(x => x.Name)
                    .Select(x => new OperationTemplateDto(x.Id,
                        x.Name,
                        x.DefaultValue,
                        x.ValueType,
                        x.BudgetTemplateId,
                        x.OperationCategoryId,
                        x.OperationCategory?.Name)));
        }
    }
}