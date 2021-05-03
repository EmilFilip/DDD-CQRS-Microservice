using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STC.Authentication.Infrastructure.Configuration;
using STC.Shared.Infrastructure.Authentication.DependencyInjection;

namespace STC.Authentication.Api.Configuration
{
    public static class ServicesInstaller
    {
        public static IServiceCollection RegisterDependencies(
           this IServiceCollection serviceCollection,
           IConfiguration configuration)
        {
            return serviceCollection
                 .RegisterCommonContainer(configuration)
                 .RegisterAuthentication();
        }
    }
}
