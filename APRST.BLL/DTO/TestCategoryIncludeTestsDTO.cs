using System.Collections.Generic;

namespace APRST.BLL.DTO
{
    public class TestCategoryIncludeTestsDTO
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }
        public string Desc { get; set; }

        public List<TestDTO> TestDtos { get; set; }
    }
}
