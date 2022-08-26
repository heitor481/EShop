using EShop.User.Api.Handlers;
using EShop.User.Api.Repositories;
using EShop.User.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Product.User.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services) 
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<CreateUserHandler>();
            return services;
        }
    }
}
