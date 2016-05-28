using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using APRST.DAL.Entities;

namespace APRST.BLL.Interfaces
{
    public interface IUserProfileService
    {
        void AddTestToProfile(int testId, int userId);
        UserProfileIncludeTestsDTO GetProfileWithTestsById(int id);
        UserProfileIncludeRoleDTO GetProfileByIdentityName(string identityName);
        UserProfileIncludeTestsDTO GetProfileWithTestsByUserIdentityName(string userIdentityName);
        void CreateProfile(UserProfileDTO user);
        IEnumerable<UserProfileDTO> GetAll();
        void UpdateProfileImage(int userId, string pathToImageInDatabase);
    }
}
