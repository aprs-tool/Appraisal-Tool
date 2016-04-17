using APRST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APRST.WEB.Controllers
{
    public class TestCategoryController : Controller
    {
        ITestCategoryService _testCategoryService;
        public TestCategoryController(ITestCategoryService service)
        {
            _testCategoryService = service;
        }
        // GET: TestCategory
        public ActionResult Index()
        {
            return View();
        }
    }
}