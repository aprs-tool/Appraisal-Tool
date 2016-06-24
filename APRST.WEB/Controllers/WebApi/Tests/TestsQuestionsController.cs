using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Tests
{
    public class TestsQuestionsController : ApiController
    {
        private readonly ITestService _testService;
        private readonly ITestQuestionService _testQuestionService;

        public TestsQuestionsController(ITestService testService, ITestQuestionService testQuestionService)
        {
            _testService = testService;
            _testQuestionService = testQuestionService;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var questions = _testService.GetQuestionsForTest(id);
            return questions != null ? Request.CreateResponse(HttpStatusCode.OK, questions) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения вопросов к тесту.");
        }

        [HttpPost]
        public HttpResponseMessage Post(TestQuestionDTO newQuestion)
        {
            //TODO: Обработать возможные исключения
            if (newQuestion == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            _testQuestionService.Add(newQuestion);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(TestQuestionDTO updatedQuestion)
        {
            //TODO: Обработать возможные исключения
            if (updatedQuestion == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            _testQuestionService.UpdateTest(updatedQuestion);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            //TODO: Обработать возможные исключения
            _testQuestionService.RemoveQuestionById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
