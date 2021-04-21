using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using STC.Shared.Infrastructure.ServiceBus;
using STC.Shared.MassTransitBus.HostedService;

namespace STC.Shared.MassTransitBus.DependencyInjection
{
    /// <summary>
    /// Helper class to simplify the process of installing MassTransitBus.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers a <see cref="MasstransitBus"/> as an <see cref="IServiceBus"/> singleton
        /// and a <see cref="BusHostedService"/> as an <see cref="IHostedService"/> singleton.
        /// </summary>
        /// <param name="services">Service collection to add MassTransitBus to.</param>
        /// <returns>Returns <paramref name="services"/> in order to allow method chaining.</returns>
        public static IServiceCollection AddMassTransitBus(this IServiceCollection services)
        {
            return services
                .AddSingleton<IServiceBus, MasstransitBus>()
                .AddSingleton<IHostedService, BusHostedService>();
        }
    }
}
