using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Entities
{
    public class QuestionnaireQuestion
    {
        public int Id { get; set; }
        public string NameOfQuestion { get; set; }
        public int QuestionnaireCategoryId { get; set; }
        public QuestionnaireCategory QuestionnaireCategory { get; set; }
    }
}
