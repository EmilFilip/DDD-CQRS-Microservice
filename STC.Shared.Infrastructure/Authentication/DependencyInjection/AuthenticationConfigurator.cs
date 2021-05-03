using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace STC.Shared.Infrastructure.Authentication.DependencyInjection
{
    public static class AuthenticationConfigurator
    {
        public static IServiceCollection RegisterAuthentication(
                this IServiceCollection serviceCollection)
        {

            serviceCollection.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthenticationConstants.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return serviceCollection.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(AuthenticationConstants.Key));
        }
    }
}
