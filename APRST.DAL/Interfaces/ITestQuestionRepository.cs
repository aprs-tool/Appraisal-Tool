using APRST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<TestQuestion> GetAnswersForQuestionAsync(int id);
        Task<IEnumerable<TestQuestion>> GetQAAsync(int testId);
    }
}
