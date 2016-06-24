using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace APRST.DAL.Repositories
{
    public class TestCategoryRepository : BaseRepository<TestCategory>, ITestCategoryRepository
    {
        public TestCategoryRepository(DbContext context):base(context)
        {
        }

        public TestCategory TestCategoryWithTests(int id)
        {
           return GetEntities().Where(s => s.Id == id).Include(src => src.Tests).FirstOrDefault();
        }
    }
}
