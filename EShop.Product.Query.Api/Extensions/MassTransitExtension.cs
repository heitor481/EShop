


using EShop.Infra.EventBus;
using EShop.Product.Query.Api.Handles;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EShop.Product.Query.Api.Extensions
{
    public static class MassTransitExtension
    {
        public static IServiceCollection AddMassTransitExtension(this IServiceCollection services, IConfiguration configuration) 
        {
            var rabbitMQ = new RabbitMQOptions();
            configuration.GetSection("RabbitMQ").Bind(rabbitMQ);

            services.AddMassTransit(x =>
            {
                x.AddConsumer<GetProductByIdHandler>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitMQ.ConnectionString), hostcfg =>
                    {
                        hostcfg.Username(rabbitMQ.Username);
                        hostcfg.Password(rabbitMQ.PassWord);
                    });

                    cfg.ConfigureEndpoints(provider);

                }));
            });

            return services;
        }
    }
}
