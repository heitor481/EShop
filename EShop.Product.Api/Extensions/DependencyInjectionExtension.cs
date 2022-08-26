using EShop.Product.Api.Handlers;
using EShop.Product.Api.Repositories;
using EShop.Product.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Product.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services) 
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<CreateProductHandler>();
            return services;
        }
    }
}
