using System.Net.Http;
using APRST.BLL.Interfaces;
using System.Web.Http;
using System.Net;
using APRST.BLL.DTO;

namespace APRST.WEB.Controllers.WebApi.Tests
{
    public class TestsController : ApiController
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var tests = _testService.GetAll();
            return tests != null ? Request.CreateResponse(HttpStatusCode.OK, tests) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения тестов.");
        }

        [HttpPost]
        public HttpResponseMessage Post(TestDTO newTest)
        {
            //TODO: Обработать возможные исключения
            if (newTest == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            _testService.AddTest(newTest);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(TestDTO updatedTest)
        {
            //TODO: Обработать возможные исключения
            if (updatedTest == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            _testService.UpdateTest(updatedTest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            //TODO: Обработать возможные исключения
            _testService.RemoveTestById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
