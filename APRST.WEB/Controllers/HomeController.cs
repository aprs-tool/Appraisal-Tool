using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.DirectoryServices.AccountManagement;
using System.Web.Mvc;

namespace APRST.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserProfileService _userProfileService;

        public HomeController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public ActionResult Index()
        {
            var profile = _userProfileService.GetProfileWithTestsByUserIdentityName(User.Identity.Name);
            if (profile == null)
            {
                return RedirectToAction("Registration");
            }

            return View();
        }

        public ActionResult Registration()
        {
            var profile = new UserProfileDTO
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
        public ActionResult Registration(UserProfileDTO profileForCreate)
        {
            _userProfileService.CreateProfile(profileForCreate);
            return RedirectToAction("Index");
        }
    }
}