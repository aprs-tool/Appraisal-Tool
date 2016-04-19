using APRST.BLL.DTO;
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
            return View(_testCategoryService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,NameOfCategory,Desc")] TestCategoryDTO category)
        {
            _testCategoryService.AddCategory(category);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var test = _testCategoryService.GetById(id);
            return View(test);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,NameOfCategory,Desc")] TestCategoryDTO category)
        {
            _testCategoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int _id = (int)id;
            return View(_testCategoryService.GetById(_id));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _testCategoryService.RemoveCategoryById(id);
            return RedirectToAction("Index");
        }


    }
}