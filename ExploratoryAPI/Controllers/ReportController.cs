using System.Web.Http;
using ExploratoryAPI.DataBase;
using MongoDB.Bson.Serialization.Attributes;

namespace ExploratoryAPI.Controllers
{
    public class ReportController : ApiController
    {
        [HttpPost]
        [Route("Add")]

        public string Add(Report report)
        {
            //send it to database
            var mongodatabase = new MongoDatabase();
            mongodatabase.Insert(report);
            var result = mongodatabase.Extract("555");
            return result.StoryNumber;

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


    [BsonIgnoreExtraElements]
    public class Report
    {
        public string StoryNumber { get; set; }
        public string Reporter { get; set; }
        public string SetUp { get; set; }
        public string Mission { get; set; }
        public string Results { get; set; }
    }
}
