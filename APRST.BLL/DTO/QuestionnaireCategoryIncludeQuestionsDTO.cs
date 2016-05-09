using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
