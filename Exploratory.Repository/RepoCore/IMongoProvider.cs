using System.Collections.Generic;
using System.Threading.Tasks;
using Exploratory.Domain.Models;
using MongoDB.Bson;

namespace Exploratory.Repository.RepoCore
{
    public interface IMongoProvider
    {
        IMongoProvider ForCollection(string collectionName);
        void Insert<T>(T model);

        Task<List<BsonDocument>> Retrieve(string storyNumber);
    }
}
