using System;
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

namespace APRST.WEB.Controllers
{
    public class UserController : Controller
    {
        private IUserProfileService _userService;
        public UserController(IUserProfileService service)
        {
            _userService = service;
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
    }
}