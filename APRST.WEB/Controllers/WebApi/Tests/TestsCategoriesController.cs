using System.Net.Http;
using APRST.BLL.Interfaces;
using System.Web.Http;
using System.Net;
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
        public HttpResponseMessage Get()
        {
            var categories = _testCategoryService.GetAll();
            return categories != null ? Request.CreateResponse(HttpStatusCode.OK, categories) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения категорий тестов.");
        }

        [HttpPost]
        public HttpResponseMessage Post(TestCategoryDTO newCategory)
        {
            //TODO: Обработать возможные исключения
            if (newCategory == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            _testCategoryService.AddCategory(newCategory);
            _logger.Info($"Добавлена категория {newCategory.NameOfCategory}");
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(TestCategoryDTO updatedCategory)
        {
            //TODO: Обработать возможные исключения
            if (updatedCategory == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            _testCategoryService.UpdateCategory(updatedCategory);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            //TODO: Обработать возможные исключения
            _testCategoryService.RemoveCategoryById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
