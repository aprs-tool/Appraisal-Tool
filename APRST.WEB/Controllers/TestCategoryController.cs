using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using APRST.WEB.Filters;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.Controllers
{
    //[AuthorizeUser(Roles = "Administrator")]
    public class TestCategoryController : Controller
    {
        private readonly ITestCategoryService _testCategoryService;
        public TestCategoryController(ITestCategoryService service)
        {
            _testCategoryService = service;
        }

        public ActionResult Index()
        {
            return PartialView();
        }

        public async Task<JsonResult> GetCategories()
        {
            return Json(Mapper.Map<IEnumerable<TestCategoryDTO>, IEnumerable<TestCategoryViewModel>>(await _testCategoryService.GetAllAsync()), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(TestCategoryViewModel category)
        {
            await _testCategoryService.AddCategoryAsync(Mapper.Map<TestCategoryViewModel, TestCategoryDTO>(category));
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var category = Mapper.Map<TestCategoryDTO, TestCategoryViewModel>(await _testCategoryService.GetByIdAsync(id));
            return View(category);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TestCategoryViewModel category)
        {
            await _testCategoryService.UpdateCategoryAsync(Mapper.Map<TestCategoryViewModel, TestCategoryDTO>(category));
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int _id = (int)id;

            return View(Mapper.Map<TestCategoryDTO, TestCategoryViewModel>(await _testCategoryService.GetByIdAsync(_id)));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _testCategoryService.RemoveCategoryByIdAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            return View(Mapper.Map<TestCategoryIncludeTestsDTO, TestCategoryIncludeTestsViewModel>(await _testCategoryService.TestCategoryWithTestsAsync(id)));
        }

    }
}