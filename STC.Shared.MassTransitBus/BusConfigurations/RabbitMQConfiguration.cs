using System;
using GreenPipes;
using MassTransit;

namespace STC.Shared.MassTransitBus.BusConfigurations
{
    public class RabbitMQConfiguration
    {
        public static IBusControl ConfigureBus(
            string rabbitMQHostUri,
            string rabbitMQUsername,
            string rabbitMQPassword)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(busConfig =>
            {
                busConfig.Host(
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
            });

            return busControl;
        }
    }
}
