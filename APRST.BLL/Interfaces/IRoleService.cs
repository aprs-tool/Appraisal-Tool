using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;

namespace APRST.BLL.Interfaces
{
    public interface IRoleService:IDisposable
    {
        void AddUsersToRole(string[] username, int roleId);
        void RemoveUsersFromRole(string[] username, int roleId);
        bool IsUserInRole(string username, string roleName);
        string[] GetUsersInRole(string roleName);
        string GetRoleForUser(string userIdentityName);
    }
}
