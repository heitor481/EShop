using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EShop.Infra.Authentication
{
    public static class Extension
    {
        public static IServiceCollection AddJWT(this IServiceCollection serviceCollection, IConfiguration config) 
        {
            var options = new JwtOptions();
            config.GetSection("JWT").Bind(options);
            serviceCollection.Configure<JwtOptions>(x => x = options);
            serviceCollection.AddSingleton<IAuthenticationHandler, AuthenticationHandler>();
            serviceCollection.AddAuthentication().AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidIssuer = options.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Secret))
                };
            });

            return serviceCollection;
        }
    }
}
