using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using AutoMapper;

namespace APRST.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        IUnitOfWork _uow ;
        public UserProfileService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddTestToProfile(int testId,string userPrincipalName)
        {
           var test = _uow.TestRepository.GetEntityById(testId);
            var profile = _uow.UserProfileRepository.GetProfileWithTests(userPrincipalName);
            profile.Tests.Add(test);
            _uow.Save();
        }

        public void CreateProfile(UserProfileDTO user)
        {
            //TODO:REFACTOR
            var profile = Mapper.Map<UserProfileDTO, UserProfile>(user);
            var role = _uow.RoleRepository.GetEntities().FirstOrDefault(s => s.Id == 1);
            profile.UserRoleId = role.Id;
            _uow.UserProfileRepository.Add(profile);
            _uow.Save();
        }

        public IEnumerable<UserProfileDTO> GetAll()
        {
           return Mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileDTO>>(_uow.UserProfileRepository.GetEntities());
        }

        public UserProfileIncludeTestsDTO GetProfileWithTests(string userPrincipalName)
        {
           return Mapper.Map<UserProfile, UserProfileIncludeTestsDTO>(
                _uow.UserProfileRepository.GetProfileWithTests(userPrincipalName));
        }
    }
}
