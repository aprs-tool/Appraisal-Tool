using APRST.BLL.DTO;
using System.Collections.Generic;

namespace APRST.BLL.Interfaces
{
    public interface ITestService
    {
        Task AddTestAsync(TestDTO testDto);
        Task RemoveTestByIdAsync(int id);
        Task UpdateTestAsync(TestDTO testDto);
        Task<IEnumerable<TestInfoDTO>> GetAllAsync();
        Task<TestDTO> GetByIdAsync(int id);
        Task<TestIncludeQuestionsDTO> GetQuestionsForTestAsync(int id);
        Task<IEnumerable<TestDTO>> GetTestsByCategoryIdAsync(int id);
        int GetCount();
        void Dispose();
    }
}
