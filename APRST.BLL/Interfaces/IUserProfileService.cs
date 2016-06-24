using System.Collections.Generic;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IUserProfileService
    {
        void AddTestToProfile(int testId, int userId);
        UserProfileIncludeTestsDTO GetProfileWithTestsById(int id);
        UserProfileIncludeRoleDTO GetProfileByIdentityName(string identityName);
        UserProfileIncludeTestsDTO GetProfileWithTestsByUserIdentityName(string userIdentityName);
        void CreateProfile(UserProfileDTO user);
        void EditProfile(UserProfileDTO user);
        IEnumerable<UserProfileDTO> GetAll();
        void UpdateProfileImage(int userId, string pathToImageInDatabase);
        int GetCount();
        
    }
}
