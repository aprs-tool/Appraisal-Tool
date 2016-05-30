using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Web;
using System.Web.Mvc;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;
using APRST.BLL.DTO;

namespace APRST.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly ITestService _testService;
        private readonly IUserProfileService _userService;

        private readonly IUserProfileService _userProfileService;

        public UserController(IUserProfileService service, ITestService testService, IUserProfileService userProfileService)
        {
            _userService = service;
            _testService = testService;
            _userProfileService = userProfileService;
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
            var profile = new UserProfileViewModel
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

        public ActionResult Profile(int id)
        {
            var profile = _userService.GetProfileWithTestsById(id);

            return View("Index", Mapper.Map<UserProfileIncludeTestsDTO, UserProfileIncludeTestsViewModel>(profile));
        }

        public ActionResult UpdateProfileImage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult UpdateProfileImage(HttpPostedFileBase file)
        {
            var user = _userProfileService.GetProfileByIdentityName(User.Identity.Name);

            if (file == null) return RedirectToAction("Index");
            if (Path.GetExtension(file.FileName) != ".png")
            {
                //TODO:Реализовать возврат сообщения о неверном формате
                ViewBag.error = "Формат изображения должен быть png";
                return RedirectToAction("Index");
            }
            var pathOnServer = Path.Combine(
                Server.MapPath("~/Users_Data/"), $"{user.Id}{Path.GetExtension(file.FileName)}");
            string pathInDatabase = $"/Users_Data/{user.Id}{Path.GetExtension(file.FileName)}";
            file.SaveAs(pathOnServer);

            _userService.UpdateProfileImage(user.Id, pathInDatabase);
            return RedirectToRoute(new
            {
                controller = "User",
                action = "Index"
            });
        }

        public JsonResult GetProfile()
        {
            return Json(_userProfileService.GetProfileByIdentityName(User.Identity.Name), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditProfile()
        {
            return PartialView();
        }

        [HttpPost]
        public void EditProfile(UserProfileViewModel profileEdit)
        {
            _userProfileService.EditProfile(Mapper.Map<UserProfileViewModel, UserProfileDTO>(profileEdit));
        }
    }
}