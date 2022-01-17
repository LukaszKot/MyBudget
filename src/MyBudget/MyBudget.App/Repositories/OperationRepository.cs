using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBudget.App.Database;
using MyBudget.App.Domain;

namespace MyBudget.App.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly AppDbContext _dbContext;
        public OperationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Operation operation)
        {
            await _dbContext.Operations.AddAsync(operation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Operation operation)
        {
            _dbContext.Operations.Update(operation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Operation> Get(Guid id)
        {
            return await _dbContext.Operations.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(Operation operation)
        {
            _dbContext.Operations.Remove(operation);
            await _dbContext.SaveChangesAsync();
        }
    }
}