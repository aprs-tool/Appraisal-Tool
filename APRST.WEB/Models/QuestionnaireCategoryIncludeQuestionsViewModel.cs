using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class QuestionnaireCategoryIncludeQuestionsViewModel
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }
        public string Desc { get; set; }
        public List<QuestionnaireQuestionViewModel> Questions { get; set; }

    }
}