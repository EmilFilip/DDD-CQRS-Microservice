using System.Diagnostics.CodeAnalysis;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STC.Shared.MassTransitBus.BusConfigurations;

namespace STC.Customer.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class MessageBrokerInstaller
    {
        public static void RegisterMessageBroker(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddBus(b => SetupRabbitMq(configuration));
            });
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
