﻿using Basis.Desafio.Infra.MongoDb.Collections;
using MongoDB.Driver;

namespace Basis.Desafio.Infra.MongoDb.Context
{
    public interface IMongoContext
    {
        IMongoCollection<LivroCollection> CollectionLivro { get; }
        IMongoCollection<AssuntoCollection> CollectionAssunto { get; }
        IMongoCollection<AutorCollection> CollectionAutor { get; }
    }
}