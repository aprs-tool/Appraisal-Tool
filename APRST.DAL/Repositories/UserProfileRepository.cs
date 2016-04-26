using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;

namespace APRST.DAL.Repositories
{
    public class UserProfileRepository:BaseRepository<UserProfile>,IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {
        }

        public UserProfile GetProfileWithTests(string userPrincipalName)
        {
            return GetEntities()
                .Where(s => s.UserPrincipalName == userPrincipalName)
                .Include(r => r.Tests)
                .FirstOrDefault();
        }
    }
}
