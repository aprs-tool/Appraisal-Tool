using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> Post(QuestionnaireQuestionDTO newQuestion)
        {
            //TODO: Обработать возможные исключения
            if (newQuestion == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            await _questionnaireQuestionService.AddAsync(newQuestion);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(QuestionnaireQuestionDTO updatedQuestion)
        {
            //TODO: Обработать возможные исключения
            if (updatedQuestion == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            await _questionnaireQuestionService.UpdateQuestionAsync(updatedQuestion);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            //TODO: Обработать возможные исключения
            await _questionnaireQuestionService.RemoveQuestionByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
