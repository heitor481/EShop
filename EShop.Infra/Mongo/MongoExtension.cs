using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using Microsoft.Extensions.Configuration;

namespace EShop.Infra.Mongo
{
    public static class MongoExtension
    {
        public static void AddMongoDB(this IServiceCollection services, IConfiguration configuration) 
        {
            var configSection = configuration.GetSection("Mongo");

            if (configSection == null) 
            {
                throw new Exception("Section not found");
            }

            var mongoConfig = new MongoConfig(configSection["ConnectionString"], configSection["Database"]);
            
            services.AddSingleton<IMongoClient>(client => 
            {
                return new MongoClient(mongoConfig.ConnectionString);
            });

            services.AddSingleton<IMongoDatabase>(client =>
            {
                var mongoClient = client.GetService<IMongoClient>();
                return mongoClient.GetDatabase(mongoConfig.Database);
            });

            services.AddSingleton<IDatabaseInitializer, MongoInitializer>();
        }
    }
}
