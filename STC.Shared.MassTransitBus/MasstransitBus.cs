using System;
using System.Globalization;
using System.Threading.Tasks;
using MassTransit;
using STC.Shared.Infrastructure.ServiceBus;

namespace STC.Shared.MassTransitBus
{
    public class MasstransitBus : IServiceBus
    {
        public const string CreatedAtHeaderKey = "created-at";

        private readonly IBusControl _masstransitBus;

        public MasstransitBus(IBusControl masstransitBus)
        {
            _masstransitBus = masstransitBus ?? throw new ArgumentNullException(nameof(masstransitBus));
        }

        public Task PublishAsync<T>(object message) where T : class
        {
            return PublishAsync<T>(
                message: message,
                messageId: Guid.NewGuid(),
                createdAt: DateTime.UtcNow);
        }

        protected async Task PublishAsync<TMessage>(
            object message,
            Guid messageId,
            DateTime createdAt)
            where TMessage : class
        {
            await _masstransitBus.Publish<TMessage>(
                values: message,
                callback: ctx =>
                    SetupSendContext(
                        ctx: ctx,
                        messageId: messageId,
                        createdAt: createdAt));
        }

        public Task SendAsync<T>(
            object command,
            string queue) where T : class
        {
            return SendAsync<T>(
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
            var destinationQueueUri = new Uri(baseUri: _masstransitBus.Address, relativeUri: queue);
            var sendEndpoint = await _masstransitBus.GetSendEndpoint(destinationQueueUri);

            await sendEndpoint.Send<TMessage>(
                values: command,
                callback: ctx =>
                    SetupSendContext(
                        ctx: ctx,
                        messageId: messageId,
                        createdAt: createdAt));
        }

        private void SetupSendContext<TMessage>(
            SendContext<TMessage> ctx,
            Guid messageId,
            DateTime createdAt)
            where TMessage : class
        {
            ctx.MessageId = messageId;
            ctx.Headers.Set(
                key: CreatedAtHeaderKey,
                value: createdAt.ToString(format: "o", provider: CultureInfo.InvariantCulture));
        }
    }
}
