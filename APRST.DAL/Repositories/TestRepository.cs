using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Repositories
{
    public class TestRepository:BaseRepository<Test>,ITestRepository
    {
        public TestRepository(DbContext context):base(context)
        {
        }

        public IEnumerable<Test> TestWithCategory()
        {
            return GetEntities().Include(s => s.TestCategory);
        }

        public IEnumerable<Test> GetByIdWithCategory(int id)
        {
            return GetEntities().Include(s => s.TestCategory);
        }

        public IEnumerable<Test> GetTestByCategoryId(int id)
        {
            return GetEntities().Where(s => s.TestCategoryId == id);
        }

        public Test GetQuestionsForTest(int id)
        {
            return GetEntities().Where(s => s.Id == id).Include(pr => pr.Questions).FirstOrDefault();
        }
    }
}
