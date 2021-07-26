using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PollingModel;

namespace PollSurveyApp.API.NET.Tests.Controllers.SurveyControllerTests
{
    [TestClass]
    public class Post : TestsBase
    {
        [TestMethod]
        public void GivenModelStateIsInvalid_ReturnsBadRequest400()
        {
            Subject.ModelState.AddModelError("test", "failure");

            var result = Subject.Post(new SurveyCreate());

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void GivenCreateSurveySucceeds_ReturnOK200()
        {
            MockSurveyService
                .Setup(x => x.CreateSurvey(It.IsAny<SurveyCreate>()))
                .Returns(true);

            var result = Subject.Post(new SurveyCreate());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        
        [TestMethod]
        public void GivenCreateSurveyFailsReturnInternalServerError500()
        {
            MockSurveyService
                .Setup(x => x.CreateSurvey(It.IsAny<SurveyCreate>()))
                .Returns(false);

            var result = Subject.Post(new SurveyCreate());

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}