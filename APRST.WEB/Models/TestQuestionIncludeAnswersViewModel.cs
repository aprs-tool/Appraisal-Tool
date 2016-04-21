using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class TestQuestionIncludeAnswersViewModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<TestAnswerViewModel> Answers { get; set; }
    }
}