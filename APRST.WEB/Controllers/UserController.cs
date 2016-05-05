using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
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
        // GET: User
        public ActionResult Index()
        {
            //return principal
            var profile = _userService.GetProfileWithTests(UserPrincipal.Current.SamAccountName);
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
        public ActionResult GiveTest(string id)
        {
            ViewBag.ABC = id;
            return View(Mapper.Map<IEnumerable<TestInfoDTO>, IEnumerable<TestInfoViewModel>>(_testService.GetAll()));
        }
        [HttpPost]
        public ActionResult GiveTest(UserTestViewModel userTest)
        {
            //TODO: REFACTOR THIS (TEST COMMIT)
            _userService.AddTestToProfile(Int32.Parse(userTest.testid), userTest.userid);
            return RedirectToAction("Profile", new {id=userTest.userid});
        }

        public ActionResult All()
        {
            return View(Mapper.Map<IEnumerable<UserProfileDTO>, IEnumerable<UserProfileViewModel>>(_userService.GetAll()));
        }
        public new ActionResult Profile(string id)
        {
           var profile= _userService.GetProfileWithTests(id);
            
            return View("Index", Mapper.Map<UserProfileIncludeTestsDTO, UserProfileIncludeTestsViewModel>(profile));
        }
        public ActionResult RoleTest()
        {
            var users = new string[]
            {
                "lakhmitski",
                "lapa"
            };
            _roleService.RemoveUsersFromRole(users,2);
            return View();
        }
    }
}