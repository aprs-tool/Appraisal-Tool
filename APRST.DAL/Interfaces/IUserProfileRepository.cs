using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.DAL.Entities;

namespace APRST.DAL.Interfaces
{
    public interface IUserProfileRepository:IRepository<UserProfile>
    {
        Task<UserProfile> GetProfileWithTestsByIdAsync(int id);
        Task<UserProfile> GetProfileByIdentityNameAsync(string identityName);
        UserProfile GetProfileWithRole(string userIdentityName);
        Task<UserProfile> GetProfileWithRoleAsync(string userIdentityName);
        UserProfile GetProfileWithTestsByUserIdentityName(string userIdentityName);
        Task<UserProfile> GetProfileWithTestsByUserIdentityNameAsync(string userIdentityName);
    }
}
