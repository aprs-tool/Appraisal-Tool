using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task AddTestToProfileAsync(int testId,int userId)
        {
           var test = await _uow.TestRepository.GetEntityByIdAsync(testId);
            var profile = await _uow.UserProfileRepository.GetProfileWithTestsByIdAsync(userId);
            profile.Tests.Add(test);
            await _uow.SaveAsync();
        }

        public async Task CreateProfileAsync(UserProfileDTO user)
        {
            var profile = Mapper.Map<UserProfileDTO, UserProfile>(user);
            var role = await _uow.RoleRepository.GetEntities().FirstOrDefaultAsync(s => s.Id == 1);
            profile.UserRoleId = role.Id;
            _uow.UserProfileRepository.Add(profile);
            await _uow.SaveAsync();
        }

        public async Task EditProfileAsync(UserProfileDTO user)
        {
            var profile = Mapper.Map<UserProfileDTO, UserProfile>(user);
            _uow.UserProfileRepository.Update(profile);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<UserProfileDTO>> GetAllAsync()
        {
           return Mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileDTO>>(await _uow.UserProfileRepository.GetAllAsync());
        }

        public async Task<UserProfileIncludeRoleDTO> GetProfileByIdentityNameAsync(string userIdentityName)
        {
            return Mapper.Map<UserProfile, UserProfileIncludeRoleDTO>(
                await _uow.UserProfileRepository.GetProfileByIdentityNameAsync(userIdentityName));
        }

        public async Task<UserProfileIncludeTestsDTO> GetProfileWithTestsByIdAsync(int id)
        {
           return Mapper.Map<UserProfile, UserProfileIncludeTestsDTO>(
                await _uow.UserProfileRepository.GetProfileWithTestsByIdAsync(id));
        }

        public async Task<UserProfileIncludeTestsDTO> GetProfileWithTestsByUserIdentityNameAsync(string userIdentityName)
        {
            return Mapper.Map<UserProfile, UserProfileIncludeTestsDTO>(
                await _uow.UserProfileRepository.GetProfileWithTestsByUserIdentityNameAsync(userIdentityName));
        }

        public async Task UpdateProfileImageAsync(int userId, string pathToImageInDatabase)
        {
            var user = await _uow.UserProfileRepository.GetEntityByIdAsync(userId);
            user.Avatar = pathToImageInDatabase;
            await _uow.SaveAsync();
        }
    }
}
