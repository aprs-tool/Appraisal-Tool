using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IQuestionnaireService
    {
        void Add(QuestionnaireDTO questionnaireDto);
        void RemoveById(int id);
        void Update(QuestionnaireDTO questionnaireDto);
        QuestionnaireDTO GetByUserId(int id);
        QuestionnaireDTO QuestionnaireWithResultsByUserId(int id);
        IEnumerable<QuestionnaireTypeDTO> GetAllTypesOfQuestionnaire();
    }
}
