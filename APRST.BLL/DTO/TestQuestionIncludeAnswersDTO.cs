using System.Collections.Generic;

namespace APRST.BLL.DTO
{
    public class TestQuestionIncludeAnswersDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<TestAnswerDTO> AnswersDTO { get; set; }
    }
}
