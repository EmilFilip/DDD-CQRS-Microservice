using System.Threading.Tasks;

namespace STC.Shared.Infrastructure.ServiceBus
{
    public interface IServiceBus
    {
        Task PublishAsync<T>(object message)
            where T : class;

        Task SendAsync<T>(object command, string queue)
            where T : class;
    }
}
