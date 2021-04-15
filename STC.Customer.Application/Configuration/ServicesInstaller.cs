using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STC.Customer.Application.Queries.Parameters;
using STC.Shared.Cqrs.DependencyInjection;

namespace STC.Customer.Application.Configuration
{
    public static class ServicesInstaller
    {
        public static IServiceCollection RegisterApplicationContainer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection
                    .AddCqrs(configurator => configurator
                    .AddHandlers(typeof(GetCustomerQueryParameters).Assembly));
        }
    }
}
