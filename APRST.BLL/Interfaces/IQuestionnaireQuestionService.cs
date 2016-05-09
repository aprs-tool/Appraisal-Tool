using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IQuestionnaireQuestionService
    {
        void Add(QuestionnaireQuestionDTO question);
        void UpdateQuestion(QuestionnaireQuestionDTO question);
        void RemoveQuestionById(int id);
        QuestionnaireQuestionDTO GetById(int id);
    }
}
