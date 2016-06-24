using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace APRST.DAL.Repositories
{
    public class TestQuestionRepository : BaseRepository<TestQuestion>, ITestQuestionRepository
    {
        public TestQuestionRepository(DbContext context) : base(context)
        {
        }

        public async Task<TestQuestion> GetAnswersForQuestionAsync(int id)
        {
            return await GetEntities().Where(s => s.Id == id).Include(pr => pr.Answers).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TestQuestion>> GetQAAsync(int testId)
        {
            return await GetEntities().Where(s => s.TestId == testId).Include(pr => pr.Answers).ToListAsync();
        }
    }
}
