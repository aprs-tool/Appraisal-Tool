using System.Net.Http;
using APRST.BLL.Interfaces;
using System.Web.Http;
using System.Net;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using NLog;

namespace APRST.WEB.Controllers.WebApi.Tests
{
    public class TestsController : ApiController
    {
        private readonly ITestService _testService;
        private readonly Logger _logger;

        public TestsController(ITestService testService)
        {
            _testService = testService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            var tests =  await _testService.GetAllAsync();
            return tests != null ? Request.CreateResponse(HttpStatusCode.OK, tests) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения тестов.");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(TestDTO newTest)
        {
            //TODO: Обработать возможные исключения
            if (newTest == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            await _testService.AddTestAsync(newTest);
            _logger.Info($"Добавлен новый тест {newTest.NameOfTest}");
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(TestDTO updatedTest)
        {
            //TODO: Обработать возможные исключения
            if (updatedTest == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            await _testService.UpdateTestAsync(updatedTest);
            _logger.Info($"Изменен тест {updatedTest.NameOfTest}");
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            //TODO: Обработать возможные исключения
            await _testService.RemoveTestByIdAsync(id);
            _logger.Info($"Удален тест под идентификатором {id}");
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
