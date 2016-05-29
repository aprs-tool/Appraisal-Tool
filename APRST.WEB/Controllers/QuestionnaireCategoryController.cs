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

        public JsonResult GetCategories()
        {
            return Json(_questionnaireCategoryService.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryWithQuestions(int id)
        {
            return Json(_questionnaireCategoryService.QuestionnaireCategoryWithQuestionsDTO(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Create(QuestionnaireCategoryViewModel category)
        {
            _questionnaireCategoryService.AddCategory(Mapper.Map<QuestionnaireCategoryViewModel, QuestionnaireCategoryDTO>(category));
            _logger.Info($"Добавлена категория {category.NameOfCategory}");
        }

        [HttpPost]
        public void Edit(QuestionnaireCategoryViewModel category)
        {
            _questionnaireCategoryService.UpdateCategory(Mapper.Map<QuestionnaireCategoryViewModel, QuestionnaireCategoryDTO>(category));
        }

        [HttpPost]
        public void Delete(int id)
        {
            _questionnaireCategoryService.RemoveCategoryById(id);
        }
    }
}