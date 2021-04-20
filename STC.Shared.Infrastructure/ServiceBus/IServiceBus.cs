using System.Threading.Tasks;

namespace STC.Shared.Infrastructure.ServiceBus
{
    public interface IServiceBus
    {
        Task SendAsync<T>(T command, string queue)
            where T : class;

    }
}
