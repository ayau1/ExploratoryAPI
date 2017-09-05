using Exploratory.Domain.Models;
using Exploratory.Repository.Repositories;
using ExploratoryAPI.Controllers;
using NSubstitute;
using NUnit.Framework;

namespace ExploratoryAPI.Tests
{
    class ExploratoryApiTests
    {
        [Test]
        public void ShouldCallSaveReport_When_AddIsCalledByExploratoryApp()
        {
            //arrange
            var report = new Report();
            var reportRepository = Substitute.For<IReportRepository>();
            var reportController = new ReportController(reportRepository);

            //act
            reportController.Add(report);
            //assert
            reportRepository.Received(1).SaveReport(Arg.Any<Report>());
        }
    }
}
