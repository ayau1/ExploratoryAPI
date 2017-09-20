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

        }

        public void SaveReport(Report report)
        {
            _database.Insert(report);
        }

        public async Task<Report> RetrieveReport(string storyNumber)
        {

            var report = await _database.Retrieve(storyNumber);
            return BsonSerializer.Deserialize<Report>(report.First());
        }
    }
}