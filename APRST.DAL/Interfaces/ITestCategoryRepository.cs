using APRST.DAL.Entities;

namespace APRST.DAL.Interfaces
{
    public interface ITestCategoryRepository:IRepository<TestCategory>
    {
        TestCategory TestCategoryWithTests(int id);
    }
}
