using APRST.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace APRST.DAL.Interfaces
{
    public interface ITestResultRepository : IRepository<TestResult>
    {
        List<TestResult> GetUserTestsResults(int id);
    }
}