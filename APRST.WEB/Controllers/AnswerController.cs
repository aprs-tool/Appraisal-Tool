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
        public ActionResult Create(TestAnswerViewModel answ)
        {
            _testAnswerService.Add(Mapper.Map<TestAnswerViewModel, TestAnswerDTO>(answ));

            return RedirectToRoute(new
            {
                controller = "Question",
                action = "Details",
                id = answ.QuestionId
            });
        }

        public ActionResult Edit(int id)
        {
            return PartialView(Mapper.Map<TestAnswerDTO, TestAnswerViewModel>(_testAnswerService.GetById(id)));
        }

        [HttpPost]
        public ActionResult Edit(TestAnswerViewModel answ)
        {
            _testAnswerService.UpdateAnswer(Mapper.Map<TestAnswerViewModel, TestAnswerDTO>(answ));

            return RedirectToRoute(new
            {
                controller = "Question",
                action = "Details",
                id = answ.QuestionId
            });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int answerId = (int)id;

            return PartialView(Mapper.Map<TestAnswerDTO, TestAnswerViewModel>(_testAnswerService.GetById(answerId)));
        }

        [HttpPost]
        public void Delete(int id)
        {
            _testAnswerService.RemoveAnswerById(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}