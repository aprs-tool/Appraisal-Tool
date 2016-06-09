using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
       
        public async Task<ActionResult> Index()
        {
            return View(Mapper.Map<IEnumerable<TestInfoDTO>, IEnumerable<TestInfoViewModel>>(await _testService.GetAllAsync()));
        }

        public async Task<JsonResult> GetAllTests()
        {
            return Json(Mapper.Map<IEnumerable<TestInfoDTO>, IEnumerable<TestInfoViewModel>>(await _testService.GetAllAsync()), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.TestCategoryId = new SelectList( await _categoryService.GetAllAsync(), "Id", "NameOfCategory");
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(TestViewModel test)
        {
            await _testService.AddTestAsync((Mapper.Map<TestViewModel, TestDTO>(test)));
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var test = Mapper.Map<TestDTO, TestViewModel>(await _testService.GetByIdAsync(id));
            if (test==null)
            {
                return HttpNotFound();
            }
            ViewBag.TestCategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "NameOfCategory", test.TestCategoryId);
            return PartialView(test);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TestViewModel test)
        {
            await _testService.UpdateTestAsync(Mapper.Map<TestViewModel, TestDTO>(test));
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int _id = (int)id;

            return PartialView(Mapper.Map<TestDTO, TestInfoViewModel>(await _testService.GetByIdAsync(_id)));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _testService.RemoveTestByIdAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            var test = await _testService.GetByIdAsync(id);
            ViewBag.TestName = test.NameOfTest;
            ViewBag.TestId = test.Id;
            return View();
        }

        public async Task<JsonResult> GetQuestions(int id)
        {
            return Json(Mapper.Map<TestIncludeQuestionsDTO, TestWithQuestionViewModel>( await _testService.GetQuestionsForTestAsync(id)), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Testing(int id)
        {
            var a = await _testService.GetByIdAsync(id);
            ViewBag.TestId = a.Id;
            ViewBag.TestName = a.NameOfTest;
            return View(Mapper.Map<IEnumerable<TestQuestionIncludeAnswersDTO>, IEnumerable<TestQuestionIncludeAnswersViewModel>>(await _questionService.GetQAAsync(id)));
        }

        public async Task<JsonResult> GetQnA(int id)
        {
            return Json(Mapper.Map<IEnumerable<TestQuestionIncludeAnswersDTO>, IEnumerable<TestQuestionIncludeAnswersViewModel>>(await _questionService.GetQAAsync(id)), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> AddPoints(List<TestData> testResult, int? id)
        {
            if (id == null) return HttpNotFound();
            var qna = await _questionService.GetQAAsync((int)id);

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

            await _resultService.AddAsync(result, a);
            return null;
        }

        public async Task<JsonResult> GetUserTestsResults(int id)
        {
            return Json(await _resultService.GetUserTestsResultsAsync(id), JsonRequestBehavior.AllowGet);
        }

    }
}