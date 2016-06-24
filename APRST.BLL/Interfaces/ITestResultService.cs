using APRST.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APRST.BLL.Interfaces
{
    public interface ITestResultService
    {
        Task AddAsync(TestResultDTO testResult, string userIdentitylName);
        Task RemoveByIdAsync(int id);
        Task<TestResultDTO> GetByIdAsync(int id);
        Task<List<TestResultInfoDTO>> GetUserTestsResultsAsync(int id);
    }
}