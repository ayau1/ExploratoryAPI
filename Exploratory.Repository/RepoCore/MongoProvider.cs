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
    }
}
