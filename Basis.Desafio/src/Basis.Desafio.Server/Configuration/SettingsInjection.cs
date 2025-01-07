using Basis.Desafio.Infra.MongoDb.Configuration;
using Basis.Desafio.Infra.MongoDb.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Basis.Desafio.Server.Configuration
{
    public static class SettingsInjection
    {
        public static IServiceCollection DeclareConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDbConnection"));

            services.AddSingleton<IMongoContext, MongoContext>();

            var pack = new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);

            return services;
        }
    }
}