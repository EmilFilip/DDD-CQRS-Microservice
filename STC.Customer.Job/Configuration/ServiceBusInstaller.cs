using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace STC.Customer.Job.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ServiceBusInstaller
    {
        public static void RegisterMessageBroker(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMassTransit(x =>
            {
                x.AddConsumers(Assembly.GetExecutingAssembly());

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
