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

        public async Task<IEnumerable<OperationTemplate>> GetOperationTemplatesAsync(Guid userId)
        {
            return await _dbContext.OperationTemplates
                .Where(x => x.UserId == userId)
                .Include(x => x.OperationCategory)
                .ToListAsync();
        }

        public async Task<OperationTemplate> GetAsync(Guid id)
        {
            return await _dbContext.OperationTemplates.SingleOrDefaultAsync(x => x.Id == id);
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