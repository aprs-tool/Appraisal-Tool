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
        void AddTestToProfile(int TestId, string userPrincipalName);
        UserProfileIncludeTestsDTO GetProfileWithTests(string userPrincipalName);
    }
}
