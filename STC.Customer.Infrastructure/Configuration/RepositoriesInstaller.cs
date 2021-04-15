using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using STC.Customer.Application.RepositoryContracts;
using STC.Customer.Infrastructure.Repositories;

namespace STC.Customer.Infrastructure.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class RepositoriesInstaller
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
