using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PollingService;
using PollSurveyApp.API.NET.Controllers;

namespace PollSurveyApp.API.NET.Tests.Controllers.SurveyControllerTests
{
    [TestClass]
    public abstract class TestsBase
    {
        protected SurveyController Subject;

        protected Mock<ISurveyService> MockSurveyService;

        [TestInitialize]
        public void Arrange()
        {
            MockSurveyService = new Mock<ISurveyService>();

            Subject = new SurveyController(
                MockSurveyService.Object);
        }
    }
}
