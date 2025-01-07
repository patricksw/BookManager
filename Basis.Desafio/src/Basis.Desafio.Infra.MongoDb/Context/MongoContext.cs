using Basis.Desafio.Infra.MongoDb.Collections;
using Basis.Desafio.Infra.MongoDb.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Basis.Desafio.Infra.MongoDb.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IOptions<MongoDbConfiguration> options)
        {
            var mongoConfiguration = options.Value;
            var client = new MongoClient(mongoConfiguration.GetSampleStringConnection());
            _db = client.GetDatabase(mongoConfiguration.DataBaseName);
        }
        public IMongoCollection<LivroCollection> CollectionLivro => _db.GetCollection<LivroCollection>("Livro");
    }
}