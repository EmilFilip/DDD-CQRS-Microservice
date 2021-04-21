using System;
using GreenPipes;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace STC.Shared.MassTransitBus.BusConfigurations
{
    public class RabbitMQConfiguration
    {
        public static IBusControl ConfigureBus(
            string rabbitMQHostUri,
            string rabbitMQUsername,
            string rabbitMQPassword,
            Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> serviceBusConfigurator = null)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(busConfig =>
            {
                var hostConfig = busConfig.Host(
                    hostAddress: new Uri(rabbitMQHostUri),
                    configure: host =>
                    {
                        host.Username(rabbitMQUsername);
                        host.Password(rabbitMQPassword);
                    });

                busConfig.UseRetry(retryPolicy =>
                {
                    retryPolicy.Incremental(
                        retryLimit: 5,
                        initialInterval: TimeSpan.FromMilliseconds(100),
                        intervalIncrement: TimeSpan.FromMilliseconds(100));
                });

                serviceBusConfigurator?
                    .Invoke(
                        arg1: busConfig,
                        arg2: hostConfig);
            });

            return busControl;
        }
    }
}
