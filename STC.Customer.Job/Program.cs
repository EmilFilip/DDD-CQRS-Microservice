using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using STC.Shared.MassTransitBus.HostedService;
using STC.Customer.Job.Configuration;
using STC.Customer.Infrastructure.Configuration;
using STC.Shared.Infrastructure.Configuration;

namespace STC.Customer.Job
{
    class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            CreateHostBuilder(args: args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = ConfigurationHelper.GetDefaultConfiguration();

                    services.RegisterCommonContainer(configuration);
                    services.RegisterMessageBroker(configuration);
                    services.AddSingleton<IHostedService, BusHostedService>();
                });
    }
}
