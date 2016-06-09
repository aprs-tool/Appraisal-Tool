using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace APRST.DAL.Repositories
{
    public class TestResultRepository : BaseRepository<TestResult>, ITestResultRepository
    {
        public TestResultRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<TestResult>> GetUserTestsResultsAsync(int id)
        {
            return await GetEntities()
                .Where(user => user.UserProfiles.FirstOrDefault().Id == id).Include(test => test.Test).ToListAsync();
        }
    }
}