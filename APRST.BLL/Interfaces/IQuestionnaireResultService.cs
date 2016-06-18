using APRST.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APRST.BLL.Interfaces
{
    public interface IQuestionnaireResultService
    {
        Task AddResultAsync(List<QuestionnaireResultDTO> resultDto, int userId);
        Task UpdateResultAsync(List<QuestionnaireResultDTO> resultDto);
    }
}