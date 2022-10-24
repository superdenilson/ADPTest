using ADPTest.SharedKernel.Models;
using ADPTest.SharedKernel.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ADPTest.Infrastructure.Services;

namespace ADPTest.Infrastructure
{
    public static class DependenciesInjection
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IExternalService, ExternalService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IOperationService, OperationService>();
        }
    }
}