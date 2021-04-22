using System;
using System.Diagnostics.CodeAnalysis;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STC.Customer.Job.Consumers;
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
            serviceCollection.AddMassTransit(x =>
            {
                x.AddConsumer<CustomerUpdatedConsumer>();
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("CustomerService", e =>
                    {
                        e.ConfigureConsumer<CustomerUpdatedConsumer>(context);
                    });
                });
            });
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
