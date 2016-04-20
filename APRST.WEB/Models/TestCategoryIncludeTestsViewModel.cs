using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class TestCategoryIncludeTestsViewModel
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }
        public string Desc { get; set; }
        public List<TestForCategoryViewModel> Tests { get; set; }
    }
}