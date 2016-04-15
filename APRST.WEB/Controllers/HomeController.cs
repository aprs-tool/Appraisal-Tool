using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APRST.WEB.Controllers
{
    public class HomeController : Controller
    {
        ITestService _testService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View(_testService.GetByID(1));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page.";

            return View();
        }
    }
}