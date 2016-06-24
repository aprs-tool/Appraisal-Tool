using System;
using System.Collections.Generic;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IRoleService:IDisposable
    {
        void AddUsersToRole(string[] username, int roleId);
        void RemoveUsersFromRole(string[] username, int roleId);
        bool IsUserInRole(string username, string roleName);
        string[] GetUsersInRole(string roleName);
        string GetRoleForUser(string userIdentityName);
        IEnumerable<UserRoleDTO> GetRoles();
    }
}
