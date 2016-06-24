using System.Collections.Generic;
using System.Threading.Tasks;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IUserProfileService
    {
        Task AddTestToProfileAsync(int testId, int userId);
        Task<UserProfileIncludeTestsDTO> GetProfileWithTestsByIdAsync(int id);
        Task<UserProfileIncludeRoleDTO> GetProfileByIdentityNameAsync(string userIdentityName);
        Task<UserProfileIncludeTestsDTO> GetProfileWithTestsByUserIdentityNameAsync(string userIdentityName);
        Task CreateProfileAsync(UserProfileDTO user);
        Task EditProfileAsync(UserProfileDTO user);
        Task<IEnumerable<UserProfileDTO>> GetAllAsync();
        Task UpdateProfileImageAsync(int userId, string pathToImageInDatabase);
        int GetCount();
    }
}
