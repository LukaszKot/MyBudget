using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBudget.App.Database;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<OperationCategory>> GetAll(Guid userId)
        {
            return await _dbContext.OperationCategories
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task Create(OperationCategory operationCategory)
        {
            await _dbContext.OperationCategories.AddAsync(operationCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OperationCategory> Get(Guid id)
        {
            return await _dbContext.OperationCategories
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(OperationCategory operationCategory)
        {
            _dbContext.OperationCategories.Update(operationCategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}