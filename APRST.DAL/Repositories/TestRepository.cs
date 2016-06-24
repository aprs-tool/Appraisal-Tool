using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace APRST.DAL.Repositories
{
    public class TestRepository:BaseRepository<Test>,ITestRepository
    {
        public TestRepository(DbContext context):base(context)
        {
        }

        public async Task<IEnumerable<Test>> TestWithCategoryAsync()
        {
            return await GetEntities().Include(s => s.TestCategory).ToListAsync();
        }

        public async Task<IEnumerable<Test>> GetByIdWithCategoryAsync(int id)
        {
            return await GetEntities().Include(s => s.TestCategory).ToListAsync();
        }

        public async Task<IEnumerable<Test>> GetTestByCategoryIdAsync(int id)
        {
            return await GetEntities().Where(s => s.TestCategoryId == id).ToListAsync();
        }

        public async Task<Test> GetQuestionsForTestAsync(int id)
        {
            return await GetEntities().Where(s => s.Id == id).Include(pr => pr.Questions).FirstOrDefaultAsync();
        }
    }
}
