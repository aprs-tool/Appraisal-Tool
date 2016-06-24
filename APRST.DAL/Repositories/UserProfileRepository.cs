using System.Data.Entity;
using System.Linq;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;

namespace APRST.DAL.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {
        }

        public async Task<UserProfile> GetProfileByIdentityNameAsync(string identityName)
        {
            return await GetEntities()
                .Where(s => s.UserIdentityName == identityName)
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync();
        }

        public UserProfile GetProfileWithRole(string userIdentityName)
        {
            return GetEntitiesNoTracking().Include(d => d.UserRole).FirstOrDefault(s => s.UserIdentityName == userIdentityName);
        }

        public async Task<UserProfile> GetProfileWithRoleAsync(string userIdentityName)
        {
            return await GetEntitiesNoTracking().Include(d => d.UserRole).FirstOrDefaultAsync(s => s.UserIdentityName == userIdentityName);
        }

        public async Task<UserProfile> GetProfileWithTestsByIdAsync(int id)
        {
            return await GetEntities()
                .Where(s => s.Id == id)
                .Include(r => r.Tests)
                .Include(u=>u.UserRole)
                .Include(r => r.TestResults)
                .FirstOrDefault();
        }

        public UserProfile GetProfileWithTestsByUserIdentityName(string userIdentityName)
        {
            return GetEntities()
               .Where(s => s.UserIdentityName == userIdentityName)
               .Include(r => r.Tests)
               .Include(u => u.UserRole)
               .FirstOrDefault();
        }

        public async Task<UserProfile> GetProfileWithTestsByUserIdentityNameAsync(string userIdentityName)
        {
            return await GetEntities()
                .Where(s => s.UserIdentityName == userIdentityName)
                .Include(r => r.Tests)
                .Include(u => u.UserRole)
                .Include(r => r.TestResults)
                .FirstOrDefaultAsync();
        }
    }
}
