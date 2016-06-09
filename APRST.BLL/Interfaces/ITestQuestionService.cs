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
        Task AddAsync(TestQuestionDTO questionDTO);
        Task UpdateTestAsync(TestQuestionDTO questionDTO);
        Task RemoveTestByIdAsync(int id);
        Task<IEnumerable<TestQuestionIncludeAnswersDTO>> GetQAAsync(int testId);
        Task<IEnumerable<TestQuestionInfoDTO>> GetAllAsync();
        Task<TestQuestionDTO> GetByIdAsync(int id);
        Task<TestQuestionIncludeAnswersDTO> GetAnswersForQuestionAsync(int id);
    }
}