using APRST.DAL.Entities;
using System.Collections.Generic;

namespace APRST.DAL.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<TestQuestion> GetAnswersForQuestionAsync(int id);
        Task<IEnumerable<TestQuestion>> GetQAAsync(int testId);
    }
}
