using EShop.Product.Api.Handlers;
using EShop.Product.DataProvider.Repositories;
using EShop.Product.DataProvider.Services;
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
