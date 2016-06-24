using System;
using System.Data.Entity;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;

namespace APRST.DAL.Repositories
{
    public class RoleRepository : BaseRepository<UserRole>,IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }

        public void AddUsersToRole(string[] username, int roleId)
        {
            throw new NotImplementedException();
        }

        public string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public void RemoveUsersFromRole(string[] username, int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
