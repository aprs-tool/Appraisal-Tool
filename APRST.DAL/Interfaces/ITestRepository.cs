using APRST.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APRST.DAL.Interfaces
{
    public interface ITestRepository:IRepository<Test>
    {
        Task<IEnumerable<Test>> TestWithCategoryAsync();
        Task<IEnumerable<Test>> GetByIdWithCategoryAsync(int id);
        Task<IEnumerable<Test>> GetTestByCategoryIdAsync(int id);
        Task<Test> GetQuestionsForTestAsync(int id);
    }
}
