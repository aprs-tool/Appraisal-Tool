using System;
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
        public UserProfileIncludeTestsDTO GetProfileWithTests(string userPrincipalName)
        {
           return Mapper.Map<UserProfile, UserProfileIncludeTestsDTO>(
                _uow.UserProfileRepository.GetProfileWithTests(userPrincipalName));
        }
    }
}
