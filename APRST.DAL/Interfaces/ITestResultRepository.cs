using APRST.DAL.Entities;
using System.Collections.Generic;

namespace APRST.DAL.Interfaces
{
    public interface ITestResultRepository : IRepository<TestResult>
    {
        List<TestResult> GetUserTestsResults(int id);
    }
}