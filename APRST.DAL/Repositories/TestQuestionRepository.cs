using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace APRST.DAL.Repositories
{
    public class TestQuestionRepository : BaseRepository<TestQuestion>, ITestQuestionRepository
    {
        public TestQuestionRepository(DbContext context) : base(context)
        {
        }

        public TestQuestion GetAnswersForQuestion(int id)
        {
            return GetEntities().Where(s => s.Id == id).Include(pr => pr.Answers).FirstOrDefault();
        }

        public IEnumerable<TestQuestion> GetQA(int testId)
        {
            return GetEntities().Where(s => s.TestId == testId).Include(pr => pr.Answers);
        }
    }
}
