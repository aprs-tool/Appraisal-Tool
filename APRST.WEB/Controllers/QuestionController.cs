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
        // GET: Question
        public ActionResult Index()
        {
            return View(_testQuestionService.GetAll());
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
        public ActionResult Delete(int id)
        {
            _testQuestionService.RemoveTestById(id);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            return View(Mapper.Map<TestQuestionDTO, TestQuestionViewModel>(_testQuestionService.GetById(id)));
        }
    }
}