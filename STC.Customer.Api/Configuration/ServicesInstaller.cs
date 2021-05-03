using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STC.Customer.Infrastructure.Configuration;
using STC.Shared.MassTransitBus.DependencyInjection;

namespace STC.Customer.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ServicesInstaller
    {
        public static IServiceCollection RegisterDependencies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            return serviceCollection.RegisterCommonContainer(configuration)
                                    .AddMassTransitBus();
        }
    }
}
