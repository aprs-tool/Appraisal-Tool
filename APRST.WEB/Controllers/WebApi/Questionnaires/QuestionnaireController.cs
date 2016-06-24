using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Questionnaires
{
    public class QuestionnaireController : ApiController
    {
        private readonly IQuestionnaireCategoryService _questionnaireCategoryService;

        public QuestionnaireController(IQuestionnaireCategoryService questionnaireCategoryService)
        {
            _questionnaireCategoryService = questionnaireCategoryService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var questionnaire = _questionnaireCategoryService.GetAllWithQuestions();
            return questionnaire != null ? Request.CreateResponse(HttpStatusCode.OK, questionnaire) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения шаблона анкеты.");
        }
    }
}
