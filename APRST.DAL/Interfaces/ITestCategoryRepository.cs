using APRST.DAL.Entities;

namespace APRST.DAL.Interfaces
{
    public interface ITestCategoryRepository:IRepository<TestCategory>
    {
        Task<TestCategory> TestCategoryWithTestsAsync(int id);
    }
}
