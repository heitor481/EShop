using MongoDB.Bson.Serialization.Attributes;
using System;

namespace EShop.Infra.Commnad.Product
{
    public class CreateProduct
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

    }
}
