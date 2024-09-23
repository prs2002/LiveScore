using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Models
{
    public class Score
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ScoreID { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string MatchID { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
