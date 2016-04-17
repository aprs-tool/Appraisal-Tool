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
        ITestCategoryService _categoryService;
        public HomeController(ITestService testService, ITestCategoryService categoryService)
        {
            _testService = testService;
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View(_categoryService.GetAll());
        }

        public ActionResult Contact()
        {
            return View(_testService.GetAll());
        }
    }
}