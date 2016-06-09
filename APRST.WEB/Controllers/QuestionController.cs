using System.Threading.Tasks;
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
        public async Task<ActionResult> Create(TestQuestionViewModel questionVm)
        {
            await _testQuestionService.AddAsync(Mapper.Map<TestQuestionViewModel, TestQuestionDTO>(questionVm));
            return RedirectToRoute(new
            {
                controller = "Test",
                action = "Details",
                id = questionVm.TestId
            });
        }

        public async Task<ActionResult> Edit(int id)
        {
            return PartialView(Mapper.Map<TestQuestionDTO, TestQuestionViewModel>(await _testQuestionService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TestQuestionViewModel questionVm)
        {
            await _testQuestionService.UpdateTestAsync(Mapper.Map<TestQuestionViewModel, TestQuestionDTO>(questionVm));
            return RedirectToRoute(new
            {
                controller = "Test",
                action = "Details",
                id = questionVm.TestId
            });
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int questionId = (int)id;
            return PartialView(Mapper.Map<TestQuestionDTO, TestQuestionViewModel>(await _testQuestionService.GetByIdAsync(questionId)));
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _testQuestionService.RemoveTestByIdAsync(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Details(int id)
        {
            ViewBag.QuestionId = id;
            return View();
        }

        public async Task<JsonResult> GetAnswers(int id)
        {
            return Json(Mapper.Map<TestQuestionIncludeAnswersDTO, TestQuestionIncludeAnswersViewModel>(await _testQuestionService.GetAnswersForQuestionAsync(id)), JsonRequestBehavior.AllowGet);
        }
    }
}