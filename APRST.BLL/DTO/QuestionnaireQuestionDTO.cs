using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.DTO
{
    public class QuestionnaireQuestionDTO
    {
        public int Id { get; set; }
        public string NameOfQuestion { get; set; }
        public int QuestionnaireCategoryId { get; set; }
    }
}
