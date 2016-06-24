using System.Collections.Generic;

namespace APRST.BLL.DTO
{
    public class QuestionnaireCategoryIncludeQuestionsDTO
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }
        public string Desc { get; set; }
        public List<QuestionnaireQuestionDTO> QuestionnaireQuestionDtos { get; set; }
    }
}
