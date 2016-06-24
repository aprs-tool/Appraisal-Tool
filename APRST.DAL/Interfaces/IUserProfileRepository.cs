using APRST.DAL.Entities;

namespace APRST.DAL.Interfaces
{
    public interface IUserProfileRepository:IRepository<UserProfile>
    {
        UserProfile GetProfileWithTestsById(int id);
        UserProfile GetProfileByIdentityName(string identityName);
        UserProfile GetProfileWithTestsByUserIdentityName(string userIdentityName);
        UserProfile GetProfileWithRole(string userIdentityName);
    }
}
