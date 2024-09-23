using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
    public class Match
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? MatchID { get; set; } // MongoDB uses string IDs
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Sport { get; set; }
        public DateTime StartTime { get; set; }
        public string Status { get; set; } // e.g., Scheduled, In Progress, Finished
    }

}
