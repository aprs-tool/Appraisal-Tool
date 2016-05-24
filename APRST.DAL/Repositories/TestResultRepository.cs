using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace APRST.DAL.Repositories
{
    public class TestResultRepository : BaseRepository<TestResult>, ITestResultRepository
    {
        public TestResultRepository(DbContext context) : base(context)
        {
        }

        public List<TestResult> GetUserTestsResults(int id)
        {
            return GetEntities()
                .Where(user => user.UserProfiles.FirstOrDefault().Id == id).Include(test => test.Test).ToList();
        }
    }
}