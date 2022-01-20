using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBudget.App.Commands.Budget;
using MyBudget.App.Domain;
using MyBudget.App.DTO.Budget;
using MyBudget.App.Events.Budget;
using MyBudget.App.Queries.Budget;
using MyBudget.App.Repositories;

namespace MyBudget.App.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IOperationTemplateRepository _operationTemplateRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBudgetTemplateRepository _budgetTemplateRepository;

        public BudgetService(IBudgetRepository budgetRepository, IOperationTemplateRepository operationTemplateRepository, ICategoryRepository categoryRepository, 
            IBudgetTemplateRepository budgetTemplateRepository)
        {
            _budgetRepository = budgetRepository;
            _operationTemplateRepository = operationTemplateRepository;
            _categoryRepository = categoryRepository;
            _budgetTemplateRepository = budgetTemplateRepository;
        }

        public async Task<GetBudgetsQueryResponse> GetBudgetsAsync(Guid userId)
        {
            var budgetsTemplatesTask = _budgetRepository.GetAllUserBudgetsWithRelatedTables(userId);
            var operationTemplatesTask = _operationTemplateRepository.GetOperationTemplatesAsync(userId);
            var categoriesTask = _categoryRepository.GetAll();

            var budgetsTemplates = await budgetsTemplatesTask;

            var budgetTemplates = budgetsTemplates.ToList();
            var budgetTemplatesDtos = budgetTemplates
                .Select(x => new BudgetTemplateDto(x.Id, x.Name));
            var activeBudget = budgetTemplates
                .SelectMany(x => x.Budgets)
                .Where(x => x.BudgetType == BudgetType.Active)
                .Select(x => new BudgetDto(x.Id, x.BudgetTemplate.Name, x.From, x.To));
            
            var archivedBudget = budgetTemplates
                .SelectMany(x => x.Budgets)
                .Where(x => x.BudgetType == BudgetType.Historical)
                .Select(x => new BudgetDto(x.Id, x.BudgetTemplate.Name, x.From, x.To));
            
            var operationTemplates = await operationTemplatesTask;
            var operationTemplatesDto = operationTemplates.Select(x => new OperationTemplateDto(x.Id, x.Name,
                x.DefaultValue, x.ValueType, x.BudgetTemplateId, x.OperationCategoryId, x.OperationCategory?.Name));
            
            var categories = await categoriesTask;
            var categoryDtos = categories.Select(x => new CategoryDto(x.Id, x.Name));

            return new GetBudgetsQueryResponse(budgetTemplatesDtos, activeBudget, archivedBudget, operationTemplatesDto,
                categoryDtos);
        }

        public async Task<GetBudgetOperationsQueryResponse> GetBudgetOperationsAsync(GetBudgetOperationsQuery query)
        {
            var queryResult = await _budgetRepository.GetBudgetOperations(query.Id);
            return new GetBudgetOperationsQueryResponse(queryResult.Id,
                queryResult.BudgetTemplate.Name,
                queryResult.From,
                queryResult.Total(),
                queryResult.Operations
                    .Select(x => new OperationDto(
                        x.Id, 
                        x.Name, 
                        x.Value, 
                        x.ValueType, 
                        x.Date, 
                        x.OperationTemplateId, 
                        x.OperationCategoryId, 
                        x.OperationCategory?.Name)));
        }

        public async Task<BudgetCreatedEvent> ArchiveBudgetAsync(ArchiveBudgetCommand command)
        {
            var budget = await _budgetRepository.GetBudget(command.Id);
            budget.Archive();
            await _budgetRepository.Update(budget);
            return new BudgetCreatedEvent(command.Id);
        }

        public async Task<BudgetCreatedEvent> CreateBudgetAsync(CreateBudgetCommand command)
        {
            var budgetTemplate =
                await _budgetTemplateRepository.GetBudgetTemplateWithOperationTemplates(command.BudgetTemplateId);
            var budget = new Budget(budgetTemplate);
            await _budgetRepository.Add(budget);
            return new BudgetCreatedEvent(budget.Id);
        }

        public async Task<GetArchivedBudgetOperationsQueryResponse> GetArchivedBudgetAsync(GetBudgetOperationsQuery query)
        {
            var archivedBudget = await _budgetRepository.GetBudgetOperations(query.Id);

            return new GetArchivedBudgetOperationsQueryResponse(
                archivedBudget.Id,
                archivedBudget.BudgetTemplate.Name,
                archivedBudget.From,
                archivedBudget.To!.Value,
                archivedBudget.Total(),
                archivedBudget.Operations.Select(x =>
                    new OperationDto(x.Id,
                        x.Name, x.Value,
                        x.ValueType,
                        x.Date,
                        x.OperationTemplateId,
                        x.OperationCategoryId,
                        x.OperationCategory?.Name)),
                new StatisticsDto(new List<StatisticDto>()));
        }
    }
}