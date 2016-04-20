using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.DTO
{
    public class TestIncludeQuestionsDTO
    {
        public int Id { get; set; }
        public string NameOfTest { get; set; }

        public List<TestQuestionDTO> QuestionsDTO { get; set; }

    }
}
