using System.Web.Http;

namespace ExploratoryAPI.Controllers
{
    public class ReportController : ApiController
    {
        [HttpPost]
        [Route("Add")]

        public string Add(Report report)
        {

            return report.StoryNumber;


        }

        // add some more e.g.
//        //   [HttpPost]
//        [Route("delete")]
//
//        public string Add(Report report)
//        {
//
//            return report.StoryNumber;
//
//
//        }
//look at Http verbs and play around
    }

    public class Report
    {
        public string StoryNumber { get; set; }
        public string Reporter { get; set; }
    }
}
