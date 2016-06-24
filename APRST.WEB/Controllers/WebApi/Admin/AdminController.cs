using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Admin
{
    public class AdminController : ApiController
    {
        private readonly IUserProfileService _userService;
        private readonly ILogService _logService;
        private readonly IQuestionnaireService _questionnaireService;
        private readonly ITestService _testService;
        private readonly IRoleService _roleService;

        public AdminController(IUserProfileService userService, ILogService logService, IQuestionnaireService questionnaireService, ITestService testService, IRoleService roleService)
        {
            _userService = userService;
            _logService = logService;
            _questionnaireService = questionnaireService;
            _testService = testService;
            _roleService = roleService;
        }

        [HttpGet]
        [Route("api/Admin/GetLog")]
        public HttpResponseMessage GetLog()
        {
            var logs = _logService.GetLog();
            return logs != null ? Request.CreateResponse(HttpStatusCode.OK, logs) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения логов.");
        }

        [HttpGet]
        [Route("api/Admin/GetRoles")]
        public HttpResponseMessage GetRoles()
        {
            var roles = _roleService.GetRoles();
            return roles != null ? Request.CreateResponse(HttpStatusCode.OK, roles) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения списка ролей.");
        }

        [HttpGet]
        [Route("api/Admin/GetCounters")]
        public HttpResponseMessage GetCounters()
        {
            object counters = new
            {
                usersCount = _userService.GetCount(),
                questionnairesCount = _questionnaireService.GetCount(),
                testsCount = _testService.GetCount()
            };
            return Request.CreateResponse(HttpStatusCode.OK, counters);
        }

        [HttpPost]
        public HttpResponseMessage GiveTest(UserTestViewModel userTest)
        {
            if (userTest == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            _userService.AddTestToProfile(userTest.testid, userTest.userid);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
