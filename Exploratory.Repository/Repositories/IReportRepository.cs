using System.Threading.Tasks;
using Exploratory.Domain.Models;
using Exploratory.Repository.RepoCore;

namespace Exploratory.Repository.Repositories
{
    public interface IReportRepository
    {
        MongoSaveStatus SaveReport(Report report);

        Task<Report> RetrieveReport(string storyNumber);

        MongoSaveStatus UpdateReport(Report report); 
    }
}