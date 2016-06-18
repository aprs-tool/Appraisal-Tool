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
        Task AddAsync(QuestionnaireQuestionDTO question);
        Task UpdateQuestionAsync(QuestionnaireQuestionDTO question);
        Task RemoveQuestionByIdAsync(int id);
        Task<QuestionnaireQuestionDTO> GetByIdAsync(int id);
    }
}
