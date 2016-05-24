using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.Controllers
{
    public class QuestionnaireQuestionController : Controller
    {
        private IQuestionnaireQuestionService _service;
        private IQuestionnaireCategoryService _categoryService;
        public QuestionnaireQuestionController(IQuestionnaireQuestionService service, IQuestionnaireCategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }
        // GET: QuestionnaireQuestion


        public ActionResult Create(int id)
        {
            ViewBag.CategoryId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuestionnaireQuestionViewModel question)
        {
            _service.Add(Mapper.Map<QuestionnaireQuestionViewModel, QuestionnaireQuestionDTO>(question));
            return RedirectToRoute(new
            {
                controller = "QuestionnaireCategory",
                action = "Details",
                id = question.QuestionnaireCategoryId
            });
        }

        public ActionResult Edit(int id)
        {
            var question = Mapper.Map<QuestionnaireQuestionDTO, QuestionnaireQuestionViewModel>(_service.GetById(id));
            ViewBag.QuestionnaireCategoryId = new SelectList(_categoryService.GetAll(), "Id", "NameOfCategory", question.QuestionnaireCategoryId);
            return View(question);
        }

        [HttpPost]
        public ActionResult Edit(QuestionnaireQuestionViewModel question)
        {
            _service.UpdateQuestion(Mapper.Map<QuestionnaireQuestionViewModel, QuestionnaireQuestionDTO>(question));
            return RedirectToRoute(new
            {
                controller = "QuestionnaireCategory",
                action = "Details",
                id = question.QuestionnaireCategoryId
            });
        }


        [HttpPost]
        public void Delete(int id)
        {
            _service.RemoveQuestionById(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}