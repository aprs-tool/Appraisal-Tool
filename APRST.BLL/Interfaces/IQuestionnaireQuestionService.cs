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
