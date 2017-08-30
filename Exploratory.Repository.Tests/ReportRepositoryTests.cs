using Exploratory.Domain.Models;
using Exploratory.Repository.RepoCore;
using Exploratory.Repository.Repositories;
using NUnit.Framework;
using NSubstitute;

namespace Exploratory.Repository.Tests
{
    class ReportRepositoryTests
    {
        private IMongoProvider _mongoProvider;

        [SetUp]
        public void Setup()
        {
            _mongoProvider = Substitute.For<IMongoProvider>();
        }

        [Test]
        public void ShouldCallMongoProvidersInsertMethod_When_SaveIsCalledFromReportRepository()
        {
            //Arrange
            var reportRepo = new ReportRepository(_mongoProvider);
            var report = new Report();
            
            //Act
            reportRepo.SaveReport(report);
            
            //Assert
            //we are asserting mongo provider is called
            _mongoProvider.Received(1).Insert(Arg.Any<Report>());
        }

        // create a test for report controller. It should call report repository.savereport when add is called from the controller. You need a new test project for ExploratoryAPI
    }
}
