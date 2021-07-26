using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PollingModel;

namespace PollSurveyApp.API.NET.Tests.Controllers.SurveyControllerTests
{
    [TestClass]
    public class Post : TestsBase
    {
        // given model state is invalid, return bad request (400)
        [TestMethod]
        public void GivenModelStateIsInvalid_ReturnsBadRequest400()
        {
            Subject.ModelState.AddModelError("test", "failure");

            var result = Subject.Post(new SurveyCreate());

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        // given create survey succeeds, return OK (200)
        [TestMethod]
        public void GivenCreateSurveySucceeds_ReturnOK200()
        {
            MockSurveyService
                .Setup(x => x.CreateSurvey(It.IsAny<SurveyCreate>()))
                .Returns(true);

            var result = Subject.Post(new SurveyCreate());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        // given create survey fails, return Internal Server Error (500)
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