using Microsoft.AspNet.Identity;
using PollingModel;
using PollingService;
using System.Web.Http;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace PollSurveyApp.API.NET.Controllers
{
    public class SurveyController : ApiController
    {
        private readonly ISurveyService _service;

        public SurveyController()
        {
            _service = CreateSurveyService();
        }

        /// <summary>
        /// Testing constructor
        /// </summary>
        /// <param name="service"></param>
        public SurveyController(ISurveyService service)
        {
            _service = service;
        }

        private SurveyService CreateSurveyService()
        {
            var userId = User.Identity.GetUserId();
            var surveyService = new SurveyService(userId);
            return surveyService;
        }

        [HttpPost]
        public IHttpActionResult Post(SurveyCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_service.CreateSurvey(model))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            SurveyService surveyService = CreateSurveyService();
            var Survey = surveyService.GetSurveys();
            return Ok(Survey);
        }
        [HttpGet]
        public IHttpActionResult GetId(int surveyId)
        {
            SurveyService surveyService = CreateSurveyService();
            var plan = surveyService.GetSurveyById(surveyId);
            return Ok(plan);
        }
        [HttpPut]
        public IHttpActionResult Update(SurveyEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Service = CreateSurveyService();
            if (!Service.UpdateSurvey(model))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int surveyId)
        {
            var service = CreateSurveyService();

            if (!service.DeleteSurvey(surveyId))
                return InternalServerError();
            return Ok();
        }
    }
}
