using Exploratory.Domain.Models;
using Exploratory.Repository.RepoCore;

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

        public Report RetrieveReport(string storyNumber)
        {

            var report  = _database.Retrieve(storyNumber);

            return report;
        }
    }
}