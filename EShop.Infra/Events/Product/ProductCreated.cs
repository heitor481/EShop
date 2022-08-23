using MongoDB.Bson.Serialization.Attributes;
using System;

namespace EShop.Infra.Events.Product
{
	public class ProductCreated
    {
        [BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
