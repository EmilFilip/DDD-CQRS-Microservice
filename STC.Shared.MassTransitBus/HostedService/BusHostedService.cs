using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace STC.Shared.MassTransitBus.HostedService
{
    /// <summary>
    /// Hosted service that automatically starts and stops a bus control.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BusHostedService : IHostedService
    {
        private readonly IBusControl _busControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusHostedService"/> class.
        /// </summary>
        /// <param name="busControl">The bus control to call start and stop on.</param>
        public BusHostedService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _busControl.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _busControl.StopAsync(cancellationToken);
        }
    }
}
