using APRST.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class TestWithQuestionViewModel
    {
        public int Id { get; set; }
        public string NameOfTest { get; set; }

        public List<TestQuestionViewModel> Questions { get; set; }
    }
}