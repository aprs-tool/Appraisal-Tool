using APRST.BLL.DTO;
using System.Collections.Generic;

namespace APRST.BLL.Interfaces
{
    public interface IQuestionnaireResultService
    {
        void AddResult(List<QuestionnaireResultDTO> resultDto, int userId);
        void UpdateResult(List<QuestionnaireResultDTO> resultDto);
    }
}