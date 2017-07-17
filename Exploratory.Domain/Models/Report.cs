using MongoDB.Bson.Serialization.Attributes;

namespace Exploratory.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Report
    {
        public string StoryNumber { get; set; }
        public string Reporter { get; set; }
        public string SetUp { get; set; }
        public string Mission { get; set; }
        public string Results { get; set; }
    }
}