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
            return GetEntitiesNoTracking().Include(d => d.UserRole).FirstOrDefault(s => s.UserIdentityName == userIdentityName);
        }

        public UserProfile GetProfileWithTestsById(int id)
        {
            return GetEntities()
                .Where(s => s.Id == id)
                .Include(r => r.Tests)
                .FirstOrDefault();
        }

        public UserProfile GetProfileWithTestsByUserIdentityName(string userIdentityName)
        {
            return GetEntities()
                .Where(s => s.UserIdentityName == userIdentityName)
                .Include(r => r.Tests)
                .FirstOrDefault();
        }
    }
}
