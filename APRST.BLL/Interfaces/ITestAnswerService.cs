using APRST.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
