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
    }
}