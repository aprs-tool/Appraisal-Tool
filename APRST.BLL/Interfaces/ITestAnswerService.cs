using System.Threading.Tasks;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface ITestAnswerService
    {
        Task AddAsync(TestAnswerDTO answerDTO);
        Task UpdateAnswerAsync(TestAnswerDTO answerDTO);
        Task RemoveAnswerByIdAsync(int id);
        Task<TestAnswerDTO> GetByIdAsync(int id);
    }
}
