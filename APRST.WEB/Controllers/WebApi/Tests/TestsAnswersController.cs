using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Tests
{
    public class TestsAnswersController : ApiController
    {
        private readonly ITestAnswerService _testAnswerService;
        private readonly ITestQuestionService _testQuestionService;

        public TestsAnswersController(ITestAnswerService testAnswerService, ITestQuestionService testQuestionService)
        {
            _testAnswerService = testAnswerService;
            _testQuestionService = testQuestionService;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var answers = _testQuestionService.GetAnswersForQuestion(id);
            return answers != null ? Request.CreateResponse(HttpStatusCode.OK, answers) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения ответов к вопросу.");
        }

        [HttpPost]
        public HttpResponseMessage Post(TestAnswerDTO newAnswer)
        {
            //TODO: Обработать возможные исключения
            if (newAnswer == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            _testAnswerService.Add(newAnswer);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(TestAnswerDTO updatedAnswer)
        {
            //TODO: Обработать возможные исключения
            if (updatedAnswer == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            _testAnswerService.UpdateAnswer(updatedAnswer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            //TODO: Обработать возможные исключения
            _testAnswerService.RemoveAnswerById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}