using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STC.Authentication.Application.Queries.Parameters;
using STC.Authentication.Application.RepositoryContracts;
using STC.Authentication.Infrastructure.Repositories;
using STC.Shared.Cqrs.DependencyInjection;

namespace STC.Authentication.Infrastructure.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ServicesInstaller
    {
        public static IServiceCollection RegisterCommonContainer(
                        this IServiceCollection services,
                        IConfiguration configuration)
        {
            return services
                 .AddCqrs(configurator =>
                        configurator.AddHandlers(typeof(GetLoginQueryParameters).Assembly))
                 .AddScoped<ILoginRepository, LoginRepository>();
        }
    }
}
