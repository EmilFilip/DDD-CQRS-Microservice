using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using STC.Shared.MassTransitBus.DependencyInjection;
using STC.Shared.MassTransitBus.BusConfigurations;

namespace STC.Customer.Job.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ServiceBusInstaller
    {
        public static void RegisterMessageBroker(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddMassTransit(cfg =>
            {
                cfg.AddConsumers(Assembly.GetExecutingAssembly());

                cfg.AddBus(service => SetupRabbitMq(service, configuration));
            });

            serviceCollection.AddMassTransitBus();
        }

        private static IBusControl SetupRabbitMq(
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            return RabbitMQConfiguration.ConfigureBus(
                rabbitMQHostUri: configuration.GetValue<string>("RabbitMQ:HostUri"),
                rabbitMQUsername: configuration.GetValue<string>("RabbitMQ:Username"),
                rabbitMQPassword: configuration.GetValue<string>("RabbitMQ:Password"));
        }
    }
}
