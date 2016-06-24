using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Questionnaires
{
    public class QuestionnairesQuestionsController : ApiController
    {
        private readonly IQuestionnaireQuestionService _questionnaireQuestionService;

        public QuestionnairesQuestionsController(IQuestionnaireQuestionService questionnaireQuestionService)
        {
            _questionnaireQuestionService = questionnaireQuestionService;
        }

        [HttpPost]
        public HttpResponseMessage Post(QuestionnaireQuestionDTO newQuestion)
        {
            //TODO: Обработать возможные исключения
            if (newQuestion == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            _questionnaireQuestionService.Add(newQuestion);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(QuestionnaireQuestionDTO updatedQuestion)
        {
            //TODO: Обработать возможные исключения
            if (updatedQuestion == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            _questionnaireQuestionService.UpdateQuestion(updatedQuestion);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            //TODO: Обработать возможные исключения
            _questionnaireQuestionService.RemoveQuestionById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
