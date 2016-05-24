using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Filters;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.Controllers
{
    //[AuthorizeUser(Roles = "User")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly ITestCategoryService _categoryService;
        private readonly ITestQuestionService _questionService;
        private readonly ITestResultService _resultService;

        public TestController(ITestService testService, ITestCategoryService categoryService, ITestQuestionService questionService, ITestResultService resultService)
        {
            _testService = testService;
            _categoryService = categoryService;
            _questionService = questionService;
            _resultService = resultService;
        }
       
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<TestInfoDTO>, IEnumerable<TestInfoViewModel>>(_testService.GetAll()));
        }

        public JsonResult GetAllTests()
        {
            return Json(Mapper.Map<IEnumerable<TestInfoDTO>, IEnumerable<TestInfoViewModel>>(_testService.GetAll()), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.TestCategoryId = new SelectList(_categoryService.GetAll(), "Id", "NameOfCategory");
            return PartialView();
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
            ViewBag.TestCategoryId = new SelectList(_categoryService.GetAll(), "Id", "NameOfCategory", test.TestCategoryId);
            return PartialView(test);
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

            return PartialView(Mapper.Map<TestDTO, TestInfoViewModel>(_testService.GetById(_id)));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _testService.RemoveTestById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var test = _testService.GetById(id);
            ViewBag.TestName = test.NameOfTest;
            ViewBag.TestId = test.Id;
            return View();
        }

        public JsonResult GetQuestions(int id)
        {
            return Json(Mapper.Map<TestIncludeQuestionsDTO, TestWithQuestionViewModel>(_testService.GetQuestionsForTest(id)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Testing(int id)
        {
            var a = _testService.GetById(id);
            ViewBag.TestId = a.Id;
            ViewBag.TestName = a.NameOfTest;
            return View(Mapper.Map<IEnumerable<TestQuestionIncludeAnswersDTO>, IEnumerable<TestQuestionIncludeAnswersViewModel>>(_questionService.GetQA(id)));
        }

        public JsonResult GetQnA(int id)
        {
            return Json(Mapper.Map<IEnumerable<TestQuestionIncludeAnswersDTO>, IEnumerable<TestQuestionIncludeAnswersViewModel>>(_questionService.GetQA(id)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddPoints(List<TestData> testResult, int? id)
        {
            if (id == null) return HttpNotFound();
            var qna = _questionService.GetQA((int)id);

            var points = testResult.AsParallel().Sum(
                t => int.Parse(
                    qna.FirstOrDefault(qId => qId.Id == int.Parse(t.name))
                    .AnswersDTO.FirstOrDefault(aVal => aVal.Answer == t.value)
                    .Point.ToString()
                )
            );

            var result = new TestResultDTO
            {
                TestId = (int) id,
                Point = points,
                Date = DateTime.Now
            };

            var a = User.Identity.Name;

            _resultService.Add(result, a);
            return null;
        }

        public JsonResult GetUserTestsResults(int id)
        {
            return Json(_resultService.GetUserTestsResults(id), JsonRequestBehavior.AllowGet);
        }

    }
}