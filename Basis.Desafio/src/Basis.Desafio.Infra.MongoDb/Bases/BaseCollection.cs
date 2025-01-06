using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Basis.Desafio.Infra.MongoDb.Bases
{
    public abstract class BaseCollection
    {
        [Key]
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
    }
}