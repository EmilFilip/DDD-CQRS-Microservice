using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using STC.Shared.Infrastructure.ServiceBus;

namespace STC.Shared.MassTransitBus
{
    public class MasstransitBus : IServiceBus
    {
        public async Task SendAsync<T>(
            T command,
            string queue) where T : class
        {
             await SendAsync<T>(
                command: command,
                queue: queue,
                messageId: Guid.NewGuid(),
                createdAt: DateTime.UtcNow);
        }

        protected async Task SendAsync<TMessage>(
            object command,
            string queue,
            Guid messageId,
            DateTime createdAt)
            where TMessage : class
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = command.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);
                var message = JsonConvert.SerializeObject(command);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);
            }
        }
    }
}
