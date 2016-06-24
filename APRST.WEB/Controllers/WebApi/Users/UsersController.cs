using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Users
{
    public class UsersController : ApiController
    {
        private readonly IUserProfileService _userProfileService;

        public UsersController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var users = _userProfileService.GetAll();
            return users != null ? Request.CreateResponse(HttpStatusCode.OK, users) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения списка пользователей.");
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var user = _userProfileService.GetProfileWithTestsById(id);
            return user != null ? Request.CreateResponse(HttpStatusCode.OK, user) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения данных пользователя.");
        }
    }
}
