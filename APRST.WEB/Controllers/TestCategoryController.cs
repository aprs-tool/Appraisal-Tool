using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.Controllers
{
    public class TestCategoryController : Controller
    {
        ITestCategoryService _testCategoryService;
        ITestService _testService;
        public TestCategoryController(ITestCategoryService service, ITestService testService)
        {
            _testCategoryService = service;
            _testService = testService;
        }
        // GET: TestCategory
        public ActionResult Index()
        {
            Mapper.CreateMap<TestCategoryDTO, TestCategoryViewModel>();
            return View(Mapper.Map<IEnumerable<TestCategoryDTO>, IEnumerable<TestCategoryViewModel>>(_testCategoryService.GetAll()));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestCategoryViewModel category)
        {
            Mapper.CreateMap<TestCategoryViewModel, TestCategoryDTO>();
            _testCategoryService.AddCategory(Mapper.Map<TestCategoryViewModel, TestCategoryDTO>(category));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Mapper.CreateMap<TestCategoryDTO, TestCategoryViewModel>();
            var category = Mapper.Map<TestCategoryDTO, TestCategoryViewModel>(_testCategoryService.GetById(id));
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(TestCategoryViewModel category)
        {
            Mapper.CreateMap<TestCategoryViewModel, TestCategoryDTO>();
            _testCategoryService.UpdateCategory(Mapper.Map<TestCategoryViewModel, TestCategoryDTO>(category));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int _id = (int)id;

            Mapper.CreateMap<TestCategoryDTO, TestCategoryViewModel>();
            return View(Mapper.Map<TestCategoryDTO, TestCategoryViewModel>(_testCategoryService.GetById(_id)));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _testCategoryService.RemoveCategoryById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_testService.GetTestByCategoryId(id));
        }

    }
}