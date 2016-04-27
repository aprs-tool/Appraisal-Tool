using APRST.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.Interfaces
{
    public interface ITestQuestionService
    {
        void Add(TestQuestionDTO questionDTO);
        void UpdateTest(TestQuestionDTO questionDTO);
        void RemoveTestById(int id);
        IEnumerable<TestQuestionIncludeAnswersDTO> GetQA(int testId);
        IEnumerable<TestQuestionInfoDTO> GetAll();
        TestQuestionDTO GetById(int id);
        TestQuestionIncludeAnswersDTO GetAnswersForQuestion(int id);
    }
}