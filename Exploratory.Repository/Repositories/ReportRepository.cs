using System.Linq;
using System.Threading.Tasks;
using Exploratory.Domain.Models;
using Exploratory.Repository.RepoCore;
using MongoDB.Bson.Serialization;

namespace Exploratory.Repository.Repositories
{
    public class ReportRepository: IReportRepository
    {
        private readonly IMongoProvider _database;

        public ReportRepository(IMongoProvider database)
        {
            _database = database.ForCollection("report");
            _database.CreateIndexOnCollection<Report>("report", "StoryNumber", true);
        }

        public MongoSaveStatus SaveReport(Report report)
        {
            return  _database.Insert(report);
        }

        public MongoSaveStatus UpdateReport(Report report)
        {
            return _database.Update(report);
        }

        public async Task<Report> RetrieveReport(string storyNumber)
        {

            var report = await _database.Retrieve(storyNumber);
            return BsonSerializer.Deserialize<Report>(report.First());
        }

        public async MongoSaveStatus UpdateReport(string storyNumber)
        {
            // for the database collection report, story number x
            //update the reporter, setup, mission, results

            var collection = DB.GetCollection<BsonDocument>("MasterIds");
            var report= await collection.
        }
    }
}