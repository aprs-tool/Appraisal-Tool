using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Data.Entity;

namespace APRST.DAL.Repositories
{
    public class TestAnswerRepository : BaseRepository<TestAnswer>, ITestAnswerRepository
    {
        public TestAnswerRepository(DbContext context) : base(context)
        {
        }
    }
}
