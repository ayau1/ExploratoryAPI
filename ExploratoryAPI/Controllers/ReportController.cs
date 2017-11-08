using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Add")]

        public HttpResponseMessage Add(Report report)
        {

            _reportRepository.SaveReport(report);
            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Retrieve")]

        public async Task<Report> Retrieve(string storyNumberInput)
        {
            return await _reportRepository.RetrieveReport(storyNumberInput);
            
        }


    }
}
