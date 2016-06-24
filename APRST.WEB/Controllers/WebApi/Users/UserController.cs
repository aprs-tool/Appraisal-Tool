using APRST.BLL.Interfaces;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using APRST.BLL.DTO;

namespace APRST.WEB.Controllers.WebApi.Users
{
    public class UserController : ApiController
    {
        private readonly IUserProfileService _userProfileService;

        public UserController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var user = _userProfileService.GetProfileWithTestsByUserIdentityName(User.Identity.Name);
            return user != null ? Request.CreateResponse(HttpStatusCode.OK, user) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения данных профиля.");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateProfileImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var user = _userProfileService.GetProfileByIdentityName(User.Identity.Name);

            var di = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/Users_Data/"));
            di.CreateSubdirectory(user.Id.ToString());

            var root = System.Web.HttpContext.Current.Server.MapPath($"~/Users_Data/{user.Id}");
            var provider = new StreamProvider(root);

            try
            {
                var pathInDatabase = "";
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.FileData)
                {
                    var fi = new FileInfo(file.LocalFileName);
                    pathInDatabase = $"/Users_Data/{user.Id}/{fi.Name}";
                    _userProfileService.UpdateProfileImage(user.Id, pathInDatabase);
                }
                return Request.CreateResponse(HttpStatusCode.OK, pathInDatabase);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(UserProfileDTO updatedProfile)
        {
            //TODO: Обработать возможные исключения
            if (updatedProfile == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            _userProfileService.EditProfile(updatedProfile);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }

    public class StreamProvider : MultipartFormDataStreamProvider
    {
        public StreamProvider(string uploadPath)
            : base(uploadPath)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var fileName = headers.ContentDisposition.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = System.Guid.NewGuid().ToString() + ".data";
            }
            return fileName.Replace("\"", string.Empty);
        }
    }
}
