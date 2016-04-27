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
        TestQuestion GetAnswersForQuestion(int id);
        IEnumerable<TestQuestion> GetQA(int testId);
    }
}
