using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;
using APRST.BLL.DTO;
using APRST.WEB.Models.Security;

namespace APRST.WEB.Controllers
{
    public class UserController : Controller
    {
        private ITestService _testService;
        private IUserProfileService _userService;
        private IRoleService _roleService;

        public UserController(IUserProfileService service, ITestService testService, IRoleService roleService)
        {
            _userService = service;
            _testService = testService;
            _roleService = roleService;
        }
       
        public ActionResult Index()
        {
            var profile = _userService.GetProfileWithTestsByUserIdentityName(User.Identity.Name);
            if (profile == null)
            {
                return RedirectToAction("Registration");
            }

            return View(Mapper.Map<UserProfileIncludeTestsDTO, UserProfileIncludeTestsViewModel>(profile));
        }

        public ActionResult Registration()
        {
           UserProfileViewModel profile = new UserProfileViewModel
            {
                SamAccoutName = UserPrincipal.Current.SamAccountName,
                Email = UserPrincipal.Current.EmailAddress,
                Name = UserPrincipal.Current.DisplayName,
                UserIdentityName = User.Identity.Name,
                PhoneNumber = UserPrincipal.Current.VoiceTelephoneNumber,
                UserPrincipalName = UserPrincipal.Current.UserPrincipalName
            };
            return View(profile);
        }

        [HttpPost]
        public ActionResult Registration(UserProfileViewModel profileForCreate)
        {
            _userService.CreateProfile(Mapper.Map<UserProfileViewModel, UserProfileDTO>(profileForCreate));
            return RedirectToAction("Index");
        }
        public ActionResult GiveTest(int id)
        {
            ViewBag.UserId = id;
            return PartialView(Mapper.Map<IEnumerable<TestInfoDTO>, IEnumerable<TestInfoViewModel>>(_testService.GetAll()));
        }

        [HttpPost]
        public ActionResult GiveTest(UserTestViewModel userTest)
        {
            _userService.AddTestToProfile(userTest.testid, userTest.userid);
            return RedirectToAction("Profile", new { id = userTest.userid });
        }

        public ActionResult All()
        {
            return View(Mapper.Map<IEnumerable<UserProfileDTO>, IEnumerable<UserProfileViewModel>>(_userService.GetAll()));
        }

        public JsonResult GetAll()
        {
            return Json(Mapper.Map<IEnumerable<UserProfileDTO>, IEnumerable<UserProfileViewModel>>(_userService.GetAll()), JsonRequestBehavior.AllowGet);
        }

        public new ActionResult Profile(string id)
        {
            var profile = _userService.GetProfileWithTestsById(id);
            
            return View("Index", Mapper.Map<UserProfileIncludeTestsDTO, UserProfileIncludeTestsViewModel>(profile));
        }

        public ActionResult UpdateProfileImage()
        {
            var a = _userService.GetProfileWithTestsById(34);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProfileImage(HttpPostedFileBase file)
        {
            int profileId = 34;
            if (file!=null)
            {
                if (Path.GetExtension(file.FileName) != ".png")
                {
                    //TODO:Реализовать возврат сообщения о неверном формате
                    ViewBag.error = "Формат изображения должен быть png";
                    return View();
                }
                string pathOnServer = Path.Combine(
                    Server.MapPath("~/Users_Data/"), $"{profileId}{Path.GetExtension(file.FileName)}");
                string pathInDatabase = $"/Users_Data/{profileId}{Path.GetExtension(file.FileName)}";
                file.SaveAs(pathOnServer);

                _userService.UpdateProfileImage(34,pathInDatabase);
            }
            return View();
        }
    }
}