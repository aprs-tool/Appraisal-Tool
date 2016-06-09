using System.Threading.Tasks;
using AutoMapper;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using System.Web.Mvc;
using APRST.BLL.DTO;

namespace APRST.WEB.Controllers
{
    public class AnswerController : Controller
    {
        private readonly ITestAnswerService _testAnswerService;

        public AnswerController(ITestAnswerService service)
        {
            _testAnswerService = service;
        }

        public ActionResult Create(int id)
        {
            ViewBag.QuestionId = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(TestAnswerViewModel answ)
        {
            await _testAnswerService.AddAsync(Mapper.Map<TestAnswerViewModel, TestAnswerDTO>(answ));

            return RedirectToRoute(new
            {
                controller = "Question",
                action = "Details",
                id = answ.QuestionId
            });
        }

        public async  Task<ActionResult> Edit(int id)
        {
            return PartialView(Mapper.Map<TestAnswerDTO, TestAnswerViewModel>(await _testAnswerService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TestAnswerViewModel answ)
        {
            await _testAnswerService.UpdateAnswerAsync(Mapper.Map<TestAnswerViewModel, TestAnswerDTO>(answ));

            return RedirectToRoute(new
            {
                controller = "Question",
                action = "Details",
                id = answ.QuestionId
            });
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int answerId = (int)id;

            return PartialView(Mapper.Map<TestAnswerDTO, TestAnswerViewModel>(await _testAnswerService.GetByIdAsync(answerId)));
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _testAnswerService.RemoveAnswerByIdAsync(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}