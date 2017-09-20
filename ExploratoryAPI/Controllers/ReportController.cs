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

            _reportRepository.SaveReport(report);
            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpGet]
        [Route("Retrieve")]

        public HttpResponseMessage Retrieve(string storyNumber)
        {
            _reportRepository.RetrieveReport(storyNumber);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
