using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBudget.Infrastructure.Database;

namespace MyBudget.App.HostedServices
{
    public class DatabaseMigrationHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
    
        public DatabaseMigrationHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
            await dbContext!.Database.MigrateAsync(cancellationToken: stoppingToken);
        }
    }
}

