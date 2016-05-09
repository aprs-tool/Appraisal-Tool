using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class QuestionnaireQuestionViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Вопрос")]
        public string NameOfQuestion { get; set; }
        public int QuestionnaireCategoryId { get; set; }
    }
}