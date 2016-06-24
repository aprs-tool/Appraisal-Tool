using System.Net.Http;
using APRST.BLL.Interfaces;
using System.Web.Http;
using System.Net;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using NLog;

namespace APRST.WEB.Controllers.WebApi.Tests
{
    public class TestsCategoriesController : ApiController
    {
        private readonly ITestCategoryService _testCategoryService;
        private readonly Logger _logger;

        public TestsCategoriesController(ITestCategoryService testCategoryService)
        {
            _testCategoryService = testCategoryService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            var categories = await _testCategoryService.GetAllAsync();
            return categories != null ? Request.CreateResponse(HttpStatusCode.OK, categories) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения категорий тестов.");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(TestCategoryDTO newCategory)
        {
            //TODO: Обработать возможные исключения
            if (newCategory == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            await _testCategoryService.AddCategoryAsync(newCategory);
            _logger.Info($"Добавлена категория {newCategory.NameOfCategory}");
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(TestCategoryDTO updatedCategory)
        {
            //TODO: Обработать возможные исключения
            if (updatedCategory == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            await _testCategoryService.UpdateCategoryAsync(updatedCategory);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            //TODO: Обработать возможные исключения
            await _testCategoryService.RemoveCategoryByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
