using System.Collections.Generic;
using System.Threading.Tasks;
using Exploratory.Domain.Models;
using MongoDB.Bson;

namespace Exploratory.Repository.RepoCore
{
    public interface IMongoProvider
    {
        IMongoProvider ForCollection(string collectionName);
        MongoSaveStatus Insert<T>(T model);

        MongoSaveStatus Update(Report report);

        Task<List<BsonDocument>> Retrieve(string storyNumber);

        Task CreateIndexOnCollection<T>(string collectionName, string field, bool unique);
    }
}
