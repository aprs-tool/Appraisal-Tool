using System.Web.Mvc;
using APRST.BLL.Interfaces;

namespace APRST.WEB.Controllers
{
    public class AdminController : Controller
    {

        private readonly ILogService _logService;

        public AdminController(ILogService logService)
        {
            _logService = logService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLog()
        {
            return Json(_logService.GetLog(), JsonRequestBehavior.AllowGet);
        }
    }
}