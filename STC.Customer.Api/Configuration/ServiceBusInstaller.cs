using System.Diagnostics.CodeAnalysis;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STC.Shared.MassTransitBus.BusConfigurations;
using STC.Shared.MassTransitBus.DependencyInjection;

namespace STC.Customer.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ServiceBusInstaller
    {
        public static void AddServiceBus(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddMassTransit(cfg =>
                cfg.AddBus(provider =>
                    SetupRabbitMq(configuration)));

            services.AddMassTransitBus();
        }

        private static IBusControl SetupRabbitMq(IConfiguration configuration)
        {
            return RabbitMQConfiguration.ConfigureBus(
                rabbitMQHostUri: configuration.GetValue<string>("RabbitMQ:HostUri"),
                rabbitMQUsername: configuration.GetValue<string>("RabbitMQ:Username"),
                rabbitMQPassword: configuration.GetValue<string>("RabbitMQ:Password"));
        }
    }
}
