using APRST.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace APRST.DAL.Interfaces
{
    public interface ITestResultRepository : IRepository<TestResult>
    {
        Task<List<TestResult>> GetUserTestsResultsAsync(int id);
    }
}