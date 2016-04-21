using APRST.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.Interfaces
{
    public interface ITestAnswerService
    {
        void Add(TestAnswerDTO answerDTO);
        void UpdateAnswer(TestAnswerDTO answerDTO);
        void RemoveAnswerById(int id);
        TestAnswerDTO GetById(int id);
    }
}
