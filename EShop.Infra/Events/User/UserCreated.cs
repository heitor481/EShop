using MongoDB.Bson.Serialization.Attributes;

namespace EShop.Infra.Events.User
{
    public class UserCreated
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public string Password { get; set; }
    }
}
