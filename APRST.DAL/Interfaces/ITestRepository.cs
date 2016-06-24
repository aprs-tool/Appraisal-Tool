using APRST.DAL.Entities;
using System.Collections.Generic;

namespace APRST.DAL.Interfaces
{
    public interface ITestRepository:IRepository<Test>
    {
        IEnumerable<Test> TestWithCategory();
        IEnumerable<Test> GetByIdWithCategory(int id);
        IEnumerable<Test> GetTestByCategoryId(int id);

        Test GetQuestionsForTest(int id);
    }
}
