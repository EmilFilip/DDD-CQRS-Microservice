using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STC.Customer.Application.Queries.Parameters;
using STC.Customer.Application.RepositoryContracts;
using STC.Customer.Infrastructure.DBContexts;
using STC.Customer.Infrastructure.Repositories;
using STC.Shared.Cqrs.DependencyInjection;

namespace STC.Customer.Infrastructure.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ServicesInstaller
    {
        public static IServiceCollection RegisterCommonContainer(
                        this IServiceCollection services,
                        IConfiguration configuration)
        {
            return services
                 .AddCqrs(configurator =>
                        configurator.AddHandlers(typeof(GetCustomerQueryParameters).Assembly))
                 .AddDbContext<CustomerDbContext>(
                    options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("CustomerDbConnection"));
                    })
                 .AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
