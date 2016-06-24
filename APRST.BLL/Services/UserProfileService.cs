using System.Collections.Generic;
using System.Linq;
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

        public void AddTestToProfile(int testId,int userId)
        {
           var test = _uow.TestRepository.GetEntityById(testId);
            var profile = _uow.UserProfileRepository.GetProfileWithTestsById(userId);
            profile.Tests.Add(test);
            _uow.Save();
        }

        public void CreateProfile(UserProfileDTO user)
        {
            //TODO:Реализовать инициализатор базы данных чтобы заполнялся ролями (где 1 - роль пользователь)
            var profile = Mapper.Map<UserProfileDTO, UserProfile>(user);
            var role = _uow.RoleRepository.GetEntities().FirstOrDefault(s => s.Id == 1);
            profile.UserRoleId = role.Id;
            _uow.UserProfileRepository.Add(profile);
            _uow.Save();
        }

        public void EditProfile(UserProfileDTO user)
        {
            var profile = Mapper.Map<UserProfileDTO, UserProfile>(user);
            _uow.UserProfileRepository.Update(profile);
            _uow.Save();
        }

        public IEnumerable<UserProfileDTO> GetAll()
        {
           return Mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileDTO>>(_uow.UserProfileRepository.GetEntities());
        }

        public int GetCount()
        {
            return _uow.UserProfileRepository.GetCount();
        }

        public UserProfileIncludeRoleDTO GetProfileByIdentityName(string identityName)
        {
            return Mapper.Map<UserProfile, UserProfileIncludeRoleDTO>(
                _uow.UserProfileRepository.GetProfileByIdentityName(identityName));
        }

        public UserProfileIncludeTestsDTO GetProfileWithTestsById(int id)
        {
           return Mapper.Map<UserProfile, UserProfileIncludeTestsDTO>(
                _uow.UserProfileRepository.GetProfileWithTestsById(id));
        }

        public UserProfileIncludeTestsDTO GetProfileWithTestsByUserIdentityName(string userIdentityName)
        {
            return Mapper.Map<UserProfile, UserProfileIncludeTestsDTO>(
                _uow.UserProfileRepository.GetProfileWithTestsByUserIdentityName(userIdentityName));
        }

        public void UpdateProfileImage(int userId, string pathToImageInDatabase)
        {
            var user = _uow.UserProfileRepository.GetEntityById(userId);
            user.Avatar = pathToImageInDatabase;
            _uow.Save();
        }

    }
}
