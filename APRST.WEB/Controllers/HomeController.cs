using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;

namespace APRST.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        private readonly Logger _logger;

        public HomeController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<ActionResult> Index()
        {
            var profile = await _userProfileService.GetProfileWithTestsByUserIdentityNameAsync(User.Identity.Name);
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
        public async Task<ActionResult> Registration(UserProfileDTO profileForCreate)
        {
            await _userProfileService.CreateProfileAsync(profileForCreate);
            _logger.Info($"Зарегистрирован профиль");
            return RedirectToAction("Index");
        }
    }
}