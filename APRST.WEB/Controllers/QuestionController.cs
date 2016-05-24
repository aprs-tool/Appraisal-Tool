using AutoMapper;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using System.Web.Mvc;

namespace APRST.WEB.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ITestQuestionService _testQuestionService;

        public QuestionController(ITestQuestionService service)
        {
            _testQuestionService = service;
        }

        public ActionResult Create(int id)
        {
            ViewBag.TestId = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(TestQuestionViewModel questionVm)
        {
            _testQuestionService.Add(Mapper.Map<TestQuestionViewModel, TestQuestionDTO>(questionVm));
            return RedirectToRoute(new
            {
                controller = "Test",
                action = "Details",
                id = questionVm.TestId
            });
        }

        public ActionResult Edit(int id)
        {
            return PartialView(Mapper.Map<TestQuestionDTO, TestQuestionViewModel>(_testQuestionService.GetById(id)));
        }

        [HttpPost]
        public ActionResult Edit(TestQuestionViewModel questionVm)
        {
            _testQuestionService.UpdateTest(Mapper.Map<TestQuestionViewModel, TestQuestionDTO>(questionVm));
            return RedirectToRoute(new
            {
                controller = "Test",
                action = "Details",
                id = questionVm.TestId
            });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int questionId = (int)id;
            return PartialView(Mapper.Map<TestQuestionDTO, TestQuestionViewModel>(_testQuestionService.GetById(questionId)));
        }

        [HttpPost]
        public void Delete(int id)
        {
            _testQuestionService.RemoveTestById(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Details(int id)
        {
            ViewBag.QuestionId = id;
            return View();
        }

        public JsonResult GetAnswers(int id)
        {
            return Json(Mapper.Map<TestQuestionIncludeAnswersDTO, TestQuestionIncludeAnswersViewModel>(_testQuestionService.GetAnswersForQuestion(id)), JsonRequestBehavior.AllowGet);
        }
    }
}