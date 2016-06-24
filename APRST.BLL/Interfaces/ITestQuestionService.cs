using APRST.BLL.DTO;
using System.Collections.Generic;

namespace APRST.BLL.Interfaces
{
    public interface ITestQuestionService
    {
        void Add(TestQuestionDTO questionDTO);
        void UpdateTest(TestQuestionDTO questionDTO);
        void RemoveQuestionById(int id);
        IEnumerable<TestQuestionIncludeAnswersDTO> GetQA(int testId);
        IEnumerable<TestQuestionInfoDTO> GetAll();
        TestQuestionDTO GetById(int id);
        TestQuestionIncludeAnswersDTO GetAnswersForQuestion(int id);
    }
}