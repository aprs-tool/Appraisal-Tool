using System.Collections.Generic;
using System.Threading.Tasks;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IQuestionnaireService
    {
        Task AddAsync(QuestionnaireDTO questionnaireDto);
        Task RemoveByIdAsync(int id);
        Task UpdateAsync(QuestionnaireDTO questionnaireDto);
        Task<QuestionnaireDTO> GetByUserIdAsync(int id);
        Task<QuestionnaireDTO> QuestionnaireWithResultsByUserIdAsync(int id);
        Task<IEnumerable<QuestionnaireTypeDTO>> GetAllTypesOfQuestionnaireAsync();
        Task<IEnumerable<QuestionnairesDTO>> GetAllIncludeUserAndTypeAsync();
        int GetCount();
    }
}
