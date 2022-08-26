using EShop.Infra.EventBus;
using EShop.User.Api.Handlers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EShop.Product.User.Api.Extensions
{
    public static class MassTransitExtension
    {
        public static IServiceCollection AddMassTransitExtension(this IServiceCollection services, IConfiguration configuration) 
        {
            var rabbitMQ = new RabbitMQOptions();
            configuration.GetSection("RabbitMQ").Bind(rabbitMQ);

            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateUserHandler>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitMQ.ConnectionString), hostcfg =>
                    {
                        hostcfg.Username(rabbitMQ.Username);
                        hostcfg.Password(rabbitMQ.PassWord);
                    });

                    cfg.ReceiveEndpoint("create_user", c =>
                    {
                        c.PrefetchCount = 16;
                        c.UseMessageRetry(retryconfig => { retryconfig.Interval(2, 100); });
                        c.ConfigureConsumer<CreateUserHandler>(provider);

                    });
                }));
            });

            return services;
        }
    }
}
