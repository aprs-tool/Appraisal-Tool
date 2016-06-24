using System.Collections.Generic;

namespace APRST.DAL.Entities
{
    public class TestCategory
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }
        public string Desc { get; set; }
        public ICollection<Test> Tests { get; set; }
        public TestCategory()
        {
            Tests = new List<Test>();
        }
    }
}
