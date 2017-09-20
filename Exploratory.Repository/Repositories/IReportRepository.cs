using Exploratory.Domain.Models;

namespace Exploratory.Repository.Repositories
{
    public interface IReportRepository
    {
        void SaveReport(Report report);

        Report RetrieveReport(string storyNumber);
    }
}