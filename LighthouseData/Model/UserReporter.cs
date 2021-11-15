using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LighthouseData.Model
{
    public class UserReporter
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }     
    }
}