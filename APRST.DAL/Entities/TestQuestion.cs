using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Entities
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Question { get; set; }

        public Test Test { get; set; }

        public ICollection<TestAnswer> Answers { get; set; }
        public TestQuestion()
        {
            Answers = new List<TestAnswer>();
        }
    }
}
