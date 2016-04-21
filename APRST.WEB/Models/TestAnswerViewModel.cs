using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class TestAnswerViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Point { get; set; }
        public string Answer { get; set; }
    }
}