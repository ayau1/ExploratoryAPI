namespace Exploratory.Repository.RepoCore
{
    public interface IMongoProvider
    {
        IMongoProvider ForCollection(string collectionName);
        void Insert<T>(T model);
        
    }
}
