﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using APRST.DAL.Repositories;

namespace APRST.BLL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork _uow;

        public RoleService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddUsersToRole(string[] username, int roleId)
        {
            var users = _uow.UserProfileRepository.GetEntities();
            var role = _uow.RoleRepository.GetEntities().FirstOrDefault(f => f.Id == roleId);
            if (role != null)
            {
                role.UserProfiles.AddRange(username.Select(item => users.FirstOrDefault(s => s.SamAccoutName == item)));
                _uow.Save();
            }
        }

        public string GetRoleForUser(string username)
        {
            var user = _uow.UserProfileRepository.GetProfileWithRole(username);
            return user.UserRole.RoleName;
        }

        public string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string username, string roleName)
        {
            if (GetRoleForUser(username) == roleName)
            {
                return true;
            }

            return false;
        }

        public void RemoveUsersFromRole(string[] username, int roleId)
        {
            var users = _uow.UserProfileRepository.GetEntities();
            var role = _uow.RoleRepository.GetEntities().FirstOrDefault(f => f.Id == roleId);
            if (role != null)
            {
                foreach (var user in username)
                {
                    role.UserProfiles.Remove(users.FirstOrDefault(s => s.SamAccoutName == user));
                }
                _uow.Save();
            }
        }
    }
}