using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using APRST.DAL.EF;

namespace APRST.DAL.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {
        }

        public UserProfile GetProfileWithRole(string userIdentityName)
        {
            //using (AprstContext db = new AprstContext())
            //{
            //    UserProfile user = db.UserProfiles.Include(a => a.UserRole).FirstOrDefault(u => u.UserIdentityName == userIdentityName);
            //    return user;
            //}
            return GetEntities().Include(d => d.UserRole).FirstOrDefault(s => s.UserIdentityName == userIdentityName);
        }

        public UserProfile GetProfileWithTests(string userPrincipalName)
        {
            return GetEntities()
                .Where(s => s.SamAccoutName == userPrincipalName)
                .Include(r => r.Tests)
                .FirstOrDefault();
        }
    }
}
