using Microsoft.Extensions.Configuration;

namespace STC.Shared.Infrastructure.Configuration
{
    public static class ConfigurationHelper
    {
        private const string DefaultConfigurationFilePath = "appsettings.json";

        public static IConfiguration GetDefaultConfiguration(bool optional = false)
        {
            return new ConfigurationBuilder()
                .AddJsonFile(
                    path: DefaultConfigurationFilePath,
                    optional: optional,
                    reloadOnChange: true)
                .Build();
        }
    }
}
