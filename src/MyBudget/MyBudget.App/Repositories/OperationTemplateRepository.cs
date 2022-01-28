using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBudget.App.Database;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public class OperationTemplateRepository : IOperationTemplateRepository
    {
        private readonly AppDbContext _dbContext;
        public OperationTemplateRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OperationTemplate>> GetOperationTemplatesAsync(Guid userId, string? searchText=null)
        {
            var query = _dbContext.OperationTemplates
                .Include(x => x.OperationCategory)
                .Where(x => x.UserId == userId);
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => x.Name.Contains(searchText));
            }
            return await query.OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<OperationTemplate?> GetAsync(Guid id, Guid userId)
        {
            return await _dbContext.OperationTemplates
                .SingleOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task Create(OperationTemplate operationTemplate)
        {
            await _dbContext.OperationTemplates.AddAsync(operationTemplate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(OperationTemplate operationTemplate)
        {
            _dbContext.Update(operationTemplate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(OperationTemplate operationTemplate)
        {
            _dbContext.OperationTemplates.Remove(operationTemplate);
            await _dbContext.SaveChangesAsync();
        }
    }
}