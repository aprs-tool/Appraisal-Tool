using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Questionnaires
{
    public class QuestionnairesCategoriesController : ApiController
    {
        private readonly IQuestionnaireCategoryService _questionnaireCategoryService;

        public QuestionnairesCategoriesController(IQuestionnaireCategoryService questionnaireCategoryService)
        {
            _questionnaireCategoryService = questionnaireCategoryService;
        }

        [HttpPost]
        public HttpResponseMessage Post(QuestionnaireCategoryDTO newCategory)
        {
            //TODO: Обработать возможные исключения
            if (newCategory == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            _questionnaireCategoryService.AddCategory(newCategory);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(QuestionnaireCategoryDTO updatedCategory)
        {
            //TODO: Обработать возможные исключения
            if (updatedCategory == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            _questionnaireCategoryService.UpdateCategory(updatedCategory);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            //TODO: Обработать возможные исключения
            _questionnaireCategoryService.RemoveCategoryById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
