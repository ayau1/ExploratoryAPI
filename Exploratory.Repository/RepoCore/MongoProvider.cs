using System.Collections.Generic;
using System.Threading.Tasks;
using Exploratory.Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Exploratory.Repository.RepoCore
{
    public class MongoProvider:IMongoProvider
    {
        private readonly IMongoDatabase _database;
        private string _collectionName;

        public MongoProvider(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoProvider ForCollection(string collectionName)
        {
            _collectionName = collectionName;
            return this;
        }

        public void Insert<T>(T model)
        {
            _database.GetCollection<T>(_collectionName).InsertOne(model);
        }

        public async Task<List<BsonDocument>> Retrieve(string storyNumber)
        {
            // i want to retrieve an item from the collection and return it
            //I will look for the item with the matching story number

            // I need the database, collection and item.

            var collection = _database.GetCollection<BsonDocument>(_collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("StoryNumber", storyNumber);
            var reportList = await collection.Find(filter).ToListAsync();
            return reportList;
        }

    }
}
