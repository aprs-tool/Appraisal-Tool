using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Index()
        {
            var profile = await _userService.GetProfileWithTestsByUserIdentityNameAsync(User.Identity.Name);
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
        public async Task<ActionResult> Registration(UserProfileViewModel profileForCreate)
        {
            await _userService.CreateProfileAsync(Mapper.Map<UserProfileViewModel, UserProfileDTO>(profileForCreate));
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GiveTest(int id)
        {
            ViewBag.UserId = id;
            return PartialView(Mapper.Map<IEnumerable<TestInfoDTO>, IEnumerable<TestInfoViewModel>>(await _testService.GetAllAsync()));
        }

        [HttpPost]
        public async Task<ActionResult> GiveTest(UserTestViewModel userTest)
        {
            await _userService.AddTestToProfileAsync(userTest.testid, userTest.userid);
            return RedirectToAction("Profile", new { id = userTest.userid });
        }

        public async Task<ActionResult> All()
        {
            return View(Mapper.Map<IEnumerable<UserProfileDTO>, IEnumerable<UserProfileViewModel>>(await _userService.GetAllAsync()));
        }

        public async Task<JsonResult> GetAll()
        {
            return Json(Mapper.Map<IEnumerable<UserProfileDTO>, IEnumerable<UserProfileViewModel>>(await _userService.GetAllAsync()), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Profile(int id)
        {
            var profile = await _userService.GetProfileWithTestsByIdAsync(id);

            return View("Index", Mapper.Map<UserProfileIncludeTestsDTO, UserProfileIncludeTestsViewModel>(profile));
        }

        public ActionResult UpdateProfileImage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProfileImage(HttpPostedFileBase file)
        {
            var user = await _userProfileService.GetProfileByIdentityNameAsync(User.Identity.Name);

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

            await _userService.UpdateProfileImageAsync(user.Id, pathInDatabase);
            return RedirectToRoute(new
            {
                controller = "User",
                action = "Index"
            });
        }

        public async Task<JsonResult> GetProfile()
        {
            return Json(await _userProfileService.GetProfileByIdentityNameAsync(User.Identity.Name), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditProfile()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task EditProfile(UserProfileViewModel profileEdit)
        {
            await _userProfileService.EditProfileAsync(Mapper.Map<UserProfileViewModel, UserProfileDTO>(profileEdit));
        }
    }
}