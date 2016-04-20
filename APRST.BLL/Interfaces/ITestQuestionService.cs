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
        void Add(TestQuestionDTO questionDTO);
        IEnumerable<TestQuestionInfoDTO> GetAll();
    }
}
