using EShop.Infra.Authentication;
using EShop.Infra.Security;
using EShop.User.DataProvider.Repositories;
using EShop.User.DataProvider.Services;
using EShop.User.Query.Api.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Product.Query.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services) 
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEncrypter, Encrypted>();
            services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
            services.AddScoped<LoginUserHandler>();
            return services;
        }
    }
}
