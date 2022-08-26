using EShop.Product.DataProvider.Repositories;
using EShop.Product.DataProvider.Services;
using EShop.Product.Query.Api.Handles;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Product.Query.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services) 
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<GetProductByIdHandler>();
            return services;
        }
    }
}
