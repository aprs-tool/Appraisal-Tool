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

        public ActionResult Edit(int id)
        {
            var test = _testService.GetById(id);
            ViewBag.TestCategoryId = new SelectList(_categoryService.GetAll(), "Id", "NameOfCategory", test.TestCategoryId);
            return View(test);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,NameOfTest,Desc,TestCategoryId")] TestDTO test)
        {
            _testService.UpdateTest(test);
            return RedirectToAction("Contact");
        }
        public ActionResult Create()
        {
            ViewBag.TestCategoryId = new SelectList(_categoryService.GetAll(), "Id", "NameOfCategory");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,NameOfTest,Desc,TestCategoryId")] TestDTO test)
        {
            _testService.AddTest(test);
            return RedirectToAction("Contact");
        }

        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            int _id = (int)id;
            return View(_testService.GetById(_id));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _testService.RemoveTestById(id);
            return RedirectToAction("Contact");
        }
    }
}