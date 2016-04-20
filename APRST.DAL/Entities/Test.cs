using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string NameOfTest { get; set; }
        public string Desc { get; set; }
        public int? TestCategoryId { get; set; }
        public TestCategory TestCategory { get; set; }

        public ICollection<TestQuestion> Questions { get; set; }
        public Test()
        {
            Questions = new List<TestQuestion>();
        }
    }
}
