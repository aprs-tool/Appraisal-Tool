using APRST.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APRST.BLL.Interfaces
{
    public interface ITestQuestionService
    {
        Task AddAsync(TestQuestionDTO questionDTO);
        Task UpdateTestAsync(TestQuestionDTO questionDTO);
        Task RemoveQuestionByIdAsync(int id);
        Task<IEnumerable<TestQuestionIncludeAnswersDTO>> GetQAAsync(int testId);
        Task<IEnumerable<TestQuestionInfoDTO>> GetAllAsync();
        Task<TestQuestionDTO> GetByIdAsync(int id);
        Task<TestQuestionIncludeAnswersDTO> GetAnswersForQuestionAsync(int id);
    }
}