using System.Threading.Tasks;
using System.Web.Mvc;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;
using NLog;

namespace APRST.WEB.Controllers
{
    public class QuestionnaireCategoryController : Controller
    {
        private readonly IQuestionnaireCategoryService _questionnaireCategoryService;
        private readonly Logger _logger;

        public QuestionnaireCategoryController(IQuestionnaireCategoryService service)
        {
            _questionnaireCategoryService = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ActionResult Index()
        {
            return PartialView();
        }

        public async Task<JsonResult> GetCategories()
        {
            return Json(await _questionnaireCategoryService.GetAllAsync(), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetCategoryWithQuestions(int id)
        {
            return Json(await _questionnaireCategoryService.QuestionnaireCategoryWithQuestionsDTOAsync(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task Create(QuestionnaireCategoryViewModel category)
        {
            await _questionnaireCategoryService.AddCategoryAsync(Mapper.Map<QuestionnaireCategoryViewModel, QuestionnaireCategoryDTO>(category));
            _logger.Info($"Добавлена категория {category.NameOfCategory}");
        }

        [HttpPost]
        public async Task Edit(QuestionnaireCategoryViewModel category)
        {
            await _questionnaireCategoryService.UpdateCategoryAsync(Mapper.Map<QuestionnaireCategoryViewModel, QuestionnaireCategoryDTO>(category));
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _questionnaireCategoryService.RemoveCategoryByIdAsync(id);
        }
    }
}