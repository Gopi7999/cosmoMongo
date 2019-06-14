using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDBMongoAPI.Models
{
    public class Cars
    {
        [BsonId(IdGenerator =typeof(CombGuidGenerator))]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("fuel")]
        public string Fuel { get; set; }
    }
}
