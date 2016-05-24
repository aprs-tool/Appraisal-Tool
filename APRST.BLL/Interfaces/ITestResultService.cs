using APRST.BLL.DTO;
using System.Collections.Generic;

namespace APRST.BLL.Interfaces
{
    public interface ITestResultService
    {
        void Add(TestResultDTO testResult, string userIdentitylName);
        void RemoveById(int id);
        TestResultDTO GetById(int id);
        List<TestResultInfoDTO> GetUserTestsResults(int id);
    }
}