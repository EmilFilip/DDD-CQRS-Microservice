namespace STC.Shared.Infrastructure.ServiceBus
{
        using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// Abstracts a ServiceBus consumer
    /// </summary>
    /// <typeparam name="T">Message type to consume</typeparam>
    public interface IServiceBusConsumer<T> where T : class
    {
        /// <summary>
        /// Consumes a message
        /// </summary>
        /// <param name="message">message to consume</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns></returns>
        Task ConsumeAsync(T message, CancellationToken cancellationToken);
    }
}
