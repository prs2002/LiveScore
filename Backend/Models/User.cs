using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("password")]
        public required string Password { get; set; }

        [BsonElement("email")]
        public required string Email { get; set; }

        [BsonElement("userType")]
        public required string UserType { get; set; } //Manager or Executive
    }
}
