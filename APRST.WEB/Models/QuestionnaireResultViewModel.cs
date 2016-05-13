using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class QuestionnaireResultViewModel
    {
        public int Id { get; set; }
        public int QuestionnaireQuestionId { get; set; }
        public int Answer { get; set; }
    }
}