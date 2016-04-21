using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.DTO
{
    public class TestQuestionIncludeAnswersDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<TestAnswerDTO> AnswersDTO { get; set; }
    }
}
