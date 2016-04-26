using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APRST.BLL.Interfaces;

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
            //var a = 
            //_userService.GetProfileWithTests("lapa");
            _userService.AddTestToProfile(24,"lapa");
            return View();
        }
    }
}