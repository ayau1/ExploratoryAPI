using System;
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

        public MongoSaveStatus Insert<T>(T model)
        {
            try
            {
                _database.GetCollection<T>(_collectionName).InsertOne(model);
                return MongoSaveStatus.Success;
            }
            catch (MongoWriteException mwe)
            {
                //MongoWriteException and ServerErrorCategory are types returned from Mongo
                if (mwe.WriteError.Category == ServerErrorCategory.DuplicateKey)
                {
                    return MongoSaveStatus.Duplicate;
                }
                return MongoSaveStatus.Error;
            }
            catch (MongoException)
            {
                return MongoSaveStatus.Error;
            }
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

        public async Task CreateIndexOnCollection<T>(string collectionName, string field, bool unique)
        {
            var collection = _database.GetCollection<T>(collectionName);
            var keys = Builders<T>.IndexKeys.Ascending(field);
            await collection.Indexes.CreateOneAsync(keys, new CreateIndexOptions
            {
                Unique = unique
            });
        }

        public MongoSaveStatus Update(Report report)
        {

            try
            {
                _database.GetCollection<BsonDocument>(_collectionName).FindOneAndUpdate(Builders<BsonDocument>.Filter.Eq("StoryNumber", report.StoryNumber)
                , Builders<BsonDocument>.Update.Set("Reporter", report.Reporter)
                    .Set("SetUp", report.SetUp)
                    .Set("Mission", report.Mission)
                    .Set("Results", report.Results));

                return MongoSaveStatus.Success;
            }
            catch (MongoException)
            {
                return MongoSaveStatus.Error;
            }
        }
    }

    public enum MongoSaveStatus
    {
        Success,
        Duplicate,
        Error
    }
}
