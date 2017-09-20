using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<Report> Retrieve(string storyNumber)
        {
            return await _reportRepository.RetrieveReport(storyNumber);
            
        }

    }
}
