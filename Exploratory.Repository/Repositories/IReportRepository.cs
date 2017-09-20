using System.Threading.Tasks;
using Exploratory.Domain.Models;

namespace Exploratory.Repository.Repositories
{
    public interface IReportRepository
    {
        void SaveReport(Report report);

        Task<Report> RetrieveReport(string storyNumber);
    }
}