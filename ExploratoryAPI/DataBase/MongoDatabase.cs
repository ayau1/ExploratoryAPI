using System.Linq;
using ExploratoryAPI.Controllers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ExploratoryAPI.DataBase
{
    public class MongoDatabase
    {
        //this is going to connect to the db and insert our report record

        private readonly IMongoCollection<Report> _collection;
        //connection
        public MongoDatabase()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("explorator");
            _collection = database.GetCollection<Report>("report");

        }
        //insert
        public void Insert(Report report)
        {
            _collection.InsertOne(report);

        }


        public Report Extract(string storynumber)
        {
            var filter = Builders<Report>.Filter.Eq("StoryNumber",storynumber);
            var result = _collection.Find(filter).ToList();
            return result.FirstOrDefault();

        }

    }
}