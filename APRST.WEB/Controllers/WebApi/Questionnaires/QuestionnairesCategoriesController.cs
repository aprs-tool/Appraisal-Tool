using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> Post(QuestionnaireCategoryDTO newCategory)
        {
            //TODO: Обработать возможные исключения
            if (newCategory == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            await _questionnaireCategoryService.AddCategoryAsync(newCategory);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(QuestionnaireCategoryDTO updatedCategory)
        {
            //TODO: Обработать возможные исключения
            if (updatedCategory == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            await _questionnaireCategoryService.UpdateCategoryAsync(updatedCategory);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            //TODO: Обработать возможные исключения
            await _questionnaireCategoryService.RemoveCategoryByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
