using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;
using NLog;
using WebGrease.Activities;

namespace APRST.WEB.Controllers
{
    public class QuestionnaireCategoryController : Controller
    {
        private readonly IQuestionnaireCategoryService _questionnaireCategoryService;
        private readonly Logger _logger;
        public QuestionnaireCategoryController(IQuestionnaireCategoryService service)
        {
            _questionnaireCategoryService = service;
            _logger = LogManager.GetLogger("logfile");
        }
        // GET: TestCategory
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<QuestionnaireCategoryDTO>, IEnumerable<QuestionnaireCategoryViewModel>>(_questionnaireCategoryService.GetAll()));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuestionnaireCategoryViewModel category)
        {
            _questionnaireCategoryService.AddCategory(Mapper.Map<QuestionnaireCategoryViewModel, QuestionnaireCategoryDTO>(category));
            _logger.Info($"Добавлена категория {category.NameOfCategory}");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = Mapper.Map<QuestionnaireCategoryDTO, QuestionnaireCategoryViewModel>(_questionnaireCategoryService.GetById(id));
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(QuestionnaireCategoryViewModel category)
        {
            _questionnaireCategoryService.UpdateCategory(Mapper.Map<QuestionnaireCategoryViewModel, QuestionnaireCategoryDTO>(category));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void Delete(int Id)
        {
            _questionnaireCategoryService.RemoveCategoryById(Id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Details(int id)
        {
            return View(Mapper.Map<QuestionnaireCategoryIncludeQuestionsDTO, QuestionnaireCategoryIncludeQuestionsViewModel>(_questionnaireCategoryService.QuestionnaireCategoryWithQuestionsDTO(id)));
        }
    }
}