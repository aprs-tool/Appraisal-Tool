using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> Get(int id)
        {
            var questions = await _testService.GetQuestionsForTestAsync(id);
            return questions != null ? Request.CreateResponse(HttpStatusCode.OK, questions) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения вопросов к тесту.");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(TestQuestionDTO newQuestion)
        {
            //TODO: Обработать возможные исключения
            if (newQuestion == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            await _testQuestionService.AddAsync(newQuestion);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(TestQuestionDTO updatedQuestion)
        {
            //TODO: Обработать возможные исключения
            if (updatedQuestion == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            await _testQuestionService.UpdateTestAsync(updatedQuestion);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            //TODO: Обработать возможные исключения
            await _testQuestionService.RemoveQuestionByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
