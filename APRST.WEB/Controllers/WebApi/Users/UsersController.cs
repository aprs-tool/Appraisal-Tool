using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> Get()
        {
            var users = await _userProfileService.GetAllAsync();
            return users != null ? Request.CreateResponse(HttpStatusCode.OK, users) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения списка пользователей.");
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            var user = await _userProfileService.GetProfileWithTestsByIdAsync(id);
            return user != null ? Request.CreateResponse(HttpStatusCode.OK, user) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения данных пользователя.");
        }
    }
}
