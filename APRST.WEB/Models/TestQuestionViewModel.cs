using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class TestQuestionViewModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Question { get; set; }
    }
}