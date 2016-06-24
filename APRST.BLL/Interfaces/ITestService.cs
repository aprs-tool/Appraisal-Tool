using APRST.BLL.DTO;
using System.Collections.Generic;

namespace APRST.BLL.Interfaces
{
    public interface ITestService
    {
        void AddTest(TestDTO testDto);
        void RemoveTestById(int id);
        void UpdateTest(TestDTO testDto);
        IEnumerable<TestInfoDTO> GetAll();
        TestDTO GetById(int id);
        TestIncludeQuestionsDTO GetQuestionsForTest(int id);
        IEnumerable<TestDTO> GetTestsByCategoryId(int id);
        int GetCount();
        void Dispose();
    }
}
