using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Tests
{
    public class TestingController : ApiController
    {
        private readonly ITestQuestionService _testQuestionService;
        private readonly ITestResultService _testResultService;

        public TestingController(ITestQuestionService testQuestionService, ITestResultService testResultService)
        {
            _testQuestionService = testQuestionService;
            _testResultService = testResultService;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var qna = _testQuestionService.GetQA(id);
            return qna != null ? Request.CreateResponse(HttpStatusCode.OK, qna) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения списка вопросов.");
        }

        [HttpPost]
        [Route("api/Testing/Post/{id:int}")]
        public HttpResponseMessage Post([FromUri()] int? id, [FromBody]List<TestData> testResult)
        {
            if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var qna = _testQuestionService.GetQA((int)id);

            var points = testResult.AsParallel().Sum(
                t => int.Parse(
                    qna.FirstOrDefault(qId => qId.Id == int.Parse(t.name))
                    .AnswersDTO.FirstOrDefault(aVal => aVal.Answer == t.value)
                    .Point.ToString()
                )
            );

            var result = new TestResultDTO
            {
                TestId = (int)id,
                Point = points,
                Date = DateTime.Now
            };

            _testResultService.Add(result, User.Identity.Name);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
