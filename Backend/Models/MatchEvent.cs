using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Models
{
    public class MatchEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? EventID { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string MatchID { get; set; }
        public string EventType { get; set; } // e.g., Goal, Foul, Timeout
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
