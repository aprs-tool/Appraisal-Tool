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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestQuestionViewModel _question)
        {
            _testQuestionService.Add(Mapper.Map<TestQuestionViewModel, TestQuestionDTO>(_question));
            return RedirectToAction("Index");
        }
    }
}