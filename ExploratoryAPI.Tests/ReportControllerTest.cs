using System.Net;
using Exploratory.Domain.Models;
using Exploratory.Repository.RepoCore;
using Exploratory.Repository.Repositories;
using ExploratoryAPI.Controllers;
using NSubstitute;
using NUnit.Framework;

namespace ExploratoryAPI.Tests
{
    class ReportControllerTest
    {
        private Report _report;
        private IReportRepository _reportRepository;
        private ReportController _reportController;

        [SetUp]   
        public void Setup()
        {
            _report = new Report();
            _reportRepository = Substitute.For<IReportRepository>();
            _reportController = new ReportController(_reportRepository);

        }

        [Test]
        public void ShouldCallSaveReport_When_AddIsCalledByExploratoryApp()
        {
            //act
            _reportController.Add(_report);
            //assert
            _reportRepository.Received(1).SaveReport(Arg.Any<Report>());
        }

        [Test]
        public void ShouldReturnStatusCodeOK()
        {
            _reportRepository.SaveReport(_report).Returns(MongoSaveStatus.Success);

           var result= _reportController.Add(_report);

            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ShouldReturnStatusCodeConflict()
        {
            _reportRepository.SaveReport(_report).Returns(MongoSaveStatus.Duplicate);

            var result = _reportController.Add(_report);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        }
        [Test]
        public void ShouldReturnStatusCodeNotModified()
        {
            _reportRepository.SaveReport(_report).Returns(MongoSaveStatus.Error);

            var result = _reportController.Add(_report);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotModified));
        }
    }
}
