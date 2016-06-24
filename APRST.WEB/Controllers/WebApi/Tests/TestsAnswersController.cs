using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> Get(int id)
        {
            var answers = await _testQuestionService.GetAnswersForQuestionAsync(id);
            return answers != null ? Request.CreateResponse(HttpStatusCode.OK, answers) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения ответов к вопросу.");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(TestAnswerDTO newAnswer)
        {
            //TODO: Обработать возможные исключения
            if (newAnswer == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            await _testAnswerService.AddAsync(newAnswer);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(TestAnswerDTO updatedAnswer)
        {
            //TODO: Обработать возможные исключения
            if (updatedAnswer == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            await _testAnswerService.UpdateAnswerAsync(updatedAnswer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            //TODO: Обработать возможные исключения
            await _testAnswerService.RemoveAnswerByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}