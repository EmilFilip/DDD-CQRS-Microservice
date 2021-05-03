using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using STC.Customer.Infrastructure.Configuration;
using STC.Customer.Job.Configuration;
using STC.Shared.Infrastructure.Configuration;
using STC.Shared.MassTransitBus.DependencyInjection;
using STC.Shared.MassTransitBus.HostedService;

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

                    services.RegisterCommonContainer(configuration)
                            .AddMassTransitBus()
                            .RegisterMessageBroker();

                    services.AddSingleton<IHostedService, BusHostedService>();
                });
    }
}
