using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EShop.Infra.EventBus
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabitMQ(this IServiceCollection services, IConfiguration configuration) 
        {
            var conf = configuration.GetSection("RabbitMQ");
            var rabbitMQ = new RabbitMQOptions(conf["ConnectionString"], conf["Username"], conf["Password"]);

            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg => 
                {
                    cfg.Host(new Uri(rabbitMQ.ConnectionString), hostcfg =>
                    {
                        hostcfg.Username(rabbitMQ.Username);
                        hostcfg.Password(rabbitMQ.PassWord);
                    });
                }));
            });

            return services;
        }
    }
}
