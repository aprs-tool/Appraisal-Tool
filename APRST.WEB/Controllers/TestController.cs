using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Filters;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.Controllers
{
    [AuthorizeUser(Roles = "User")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly ITestCategoryService _categoryService;
        private readonly ITestQuestionService _questionService;

        public TestController(ITestService testService, ITestCategoryService categoryService, ITestQuestionService questionService)
        {
            _testService = testService;
            _categoryService = categoryService;
            _questionService = questionService;
        }
        // GET: Test
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<TestInfoDTO>, IEnumerable<TestInfoViewModel>>(_testService.GetAll()));
        }
        
        public ActionResult Create()
        {
            ViewBag.TestCategoryId = new SelectList(_categoryService.GetAll(), "Id", "NameOfCategory");
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestViewModel test)
        {
            _testService.AddTest((Mapper.Map<TestViewModel, TestDTO>(test)));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var test = Mapper.Map<TestDTO, TestViewModel>(_testService.GetById(id));
            if (test==null)
            {
                return HttpNotFound();
            }
            ViewBag.TestCategoryId = new SelectList(_categoryService.GetAll(), "Id", "NameOfCategory", test.TestCategoryId);
            return View(test);
        }

        [HttpPost]
        public ActionResult Edit(TestViewModel test)
        {
            _testService.UpdateTest(Mapper.Map<TestViewModel, TestDTO>(test));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int _id = (int)id;

            return View(Mapper.Map<TestDTO,TestInfoViewModel>(_testService.GetById(_id)));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _testService.RemoveTestById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var testDetails = Mapper.Map<TestIncludeQuestionsDTO, TestWithQuestionViewModel>(_testService.GetQuestionsForTest(id));
            if (testDetails == null)
            {
                return HttpNotFound();
            }
            return View(testDetails);
        }

        public ActionResult Testing(int id)
        {
            ViewBag.TestName = _testService.GetById(id).NameOfTest;
            return View(Mapper.Map<IEnumerable<TestQuestionIncludeAnswersDTO>, IEnumerable<TestQuestionIncludeAnswersViewModel>>(_questionService.GetQA(id)));
        }

    }
}