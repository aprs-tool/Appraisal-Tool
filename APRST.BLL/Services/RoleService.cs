using System;
using System.Collections.Generic;
using System.Linq;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using APRST.BLL.DTO;
using APRST.DAL.Entities;
using AutoMapper;

namespace APRST.BLL.Services
{

    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;

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
                role.UserProfiles.AddRange(username.Select(item => users.FirstOrDefault(s => s.UserIdentityName == item)));
                _uow.Save();
            }
        }

        public IEnumerable<UserRoleDTO> GetRoles()
        {
            return Mapper.Map<IEnumerable<UserRole>, List<UserRoleDTO>>(_uow.RoleRepository.GetEntities());
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public string GetRoleForUser(string userIdentityName)
        {
            var user = _uow.UserProfileRepository.GetProfileWithRole(userIdentityName);
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
                    role.UserProfiles.Remove(users.FirstOrDefault(s => s.UserIdentityName == user));
                }
                _uow.Save();
            }
        }
    }
}
