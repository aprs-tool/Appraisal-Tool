using AutoMapper;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APRST.WEB.Controllers
{
    public class QuestionController : Controller
    {
        ITestQuestionService _testQuestionService;

        public QuestionController(ITestQuestionService service)
        {
            _testQuestionService = service;
        }

        public ActionResult Create(int id)
        {
            ViewBag.TestId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestQuestionViewModel _question)
        {
            _testQuestionService.Add(Mapper.Map<TestQuestionViewModel, TestQuestionDTO>(_question));
            return RedirectToRoute(new
            {
                controller = "Test",
                action = "Details",
                id = _question.TestId
            });
        }

        public ActionResult Edit(int id)
        {
            var question = Mapper.Map<TestQuestionDTO, TestQuestionViewModel>(_testQuestionService.GetById(id));
            return View(question);
        }

        [HttpPost]
        public ActionResult Edit(TestQuestionViewModel qst)
        {
            _testQuestionService.UpdateTest(Mapper.Map<TestQuestionViewModel, TestQuestionDTO>(qst));
            return RedirectToRoute(new
            {
                controller = "Test",
                action = "Details",
                id = qst.TestId
            });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int _id = (int)id;
            return View(Mapper.Map<TestQuestionDTO, TestQuestionViewModel>(_testQuestionService.GetById(_id)));
        }

        [HttpPost]
        public void Delete(int id)
        {
            _testQuestionService.RemoveTestById(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }


        public ActionResult Details(int id)
        {
            return View(Mapper.Map<TestQuestionIncludeAnswersDTO, TestQuestionIncludeAnswersViewModel>(_testQuestionService.GetAnswersForQuestion(id)));
        }
    }
}