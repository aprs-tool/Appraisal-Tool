using AutoMapper;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APRST.BLL.DTO;

namespace APRST.WEB.Controllers
{
    public class AnswerController : Controller
    {
        ITestAnswerService _testAnswerService;

        public AnswerController(ITestAnswerService service)
        {
            _testAnswerService = service;
        }

        // GET: Answer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            ViewBag.QuestionId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestAnswerViewModel _answer)
        {
            _testAnswerService.Add(Mapper.Map<TestAnswerViewModel, TestAnswerDTO>(_answer));

            return RedirectToRoute(new
            {
                controller = "Question",
                action = "Details",
                id = _answer.QuestionId
            });
        }

        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<TestAnswerDTO, TestAnswerViewModel>(_testAnswerService.GetById(id)));
        }

        [HttpPost]
        public ActionResult Edit(TestAnswerViewModel _answer)
        {
            _testAnswerService.UpdateAnswer(Mapper.Map<TestAnswerViewModel, TestAnswerDTO>(_answer));

            return RedirectToRoute(new
            {
                controller = "Question",
                action = "Details",
                id = _answer.QuestionId
            });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int _id = (int)id;

            return View(Mapper.Map<TestAnswerDTO, TestAnswerViewModel>(_testAnswerService.GetById(_id)));
        }

        [HttpPost]
        public void Delete(int id)
        {
            _testAnswerService.RemoveAnswerById(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}