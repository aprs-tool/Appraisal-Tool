using APRST.DAL.Entities;
using System.Collections.Generic;

namespace APRST.DAL.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        TestQuestion GetAnswersForQuestion(int id);
        IEnumerable<TestQuestion> GetQA(int testId);
    }
}
