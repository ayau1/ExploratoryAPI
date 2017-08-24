using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exploratory.Domain.Models;
using Exploratory.Repository.Repositories;
using ExploratoryAPI.Models;

namespace ExploratoryAPI.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)//dependancy
        {
            _reportRepository = reportRepository;
        }

        [HttpPost]
        [Route("Add")]

        public HttpResponseMessage Add(Report report)
        {
            //send it to database
           // var mongodatabase = new MongoDatabase();
           // mongodatabase.Insert(report);
//            var result = mongodatabase.Extract("555");
//            return result.StoryNumber;
            _reportRepository.SaveReport(report);
            return new HttpResponseMessage(HttpStatusCode.OK);

        }
//        [HttpPost]
//        [Route("Retrieve")]
//
//        public Report Retrieve(string storyNumber)
//        {
//            //retrieve from database
//            var mongodatabase = new MongoDatabase();
//            var report = mongodatabase.Extract(storyNumber);
//            return report;

    //    }
       
    }
}
