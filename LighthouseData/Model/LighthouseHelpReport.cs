using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LighthouseData.Model
{
    public class LighthouseHelpReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReportId { get; set; }

        public UserReporter UserReporter { get; set; }
    }
}