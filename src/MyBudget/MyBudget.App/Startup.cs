using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBudget.App.Database;
using MyBudget.App.Filters;
using MyBudget.App.HostedServices;
using MyBudget.App.Middleware;
using MyBudget.App.Repositories;
using MyBudget.App.Services;

namespace MyBudget.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    
        public IConfiguration Configuration { get; }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration["SQLServerConnectionString"], builder =>
                {
                    builder.EnableRetryOnFailure();
                }), 
                ServiceLifetime.Transient);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<IBudgetTemplateRepository, BudgetTemplateRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IOperationTemplateRepository, OperationTemplateRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<IBudgetTemplateService, BudgetTemplateService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<IOperationTemplateService, OperationTemplateService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHashingService, HashingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPasswordPolicyEnforcer, PasswordPolicyEnforcer>();
            services.AddControllersWithViews(x =>
            {
                x.MaxModelValidationErrors = 50;
                x.Filters.Add<ValidateModelAttribute>();
                x.Filters.Add<ExceptionFilter>();
                x.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    _ => "Wartość musi zostać podana.");
            });
            services.AddHostedService<DatabaseMigrationHostedService>();

            services.AddHttpContextAccessor();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x => x.LoginPath = "/user/login");

        }
    
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<BodyRewindMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
    
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
    
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

