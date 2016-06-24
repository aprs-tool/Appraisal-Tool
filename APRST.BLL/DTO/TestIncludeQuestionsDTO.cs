using System.Collections.Generic;

namespace APRST.BLL.DTO
{
    public class TestIncludeQuestionsDTO
    {
        public int Id { get; set; }
        public string NameOfTest { get; set; }
        public List<TestQuestionDTO> QuestionsDTO { get; set; }

    }
}
