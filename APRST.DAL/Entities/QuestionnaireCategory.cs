using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Entities
{
    public class QuestionnaireCategory
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }
        public string Desc { get; set; }
        public List<QuestionnaireQuestion> QuestionnaireQuestions { get; set; }
        public QuestionnaireCategory()
        {
            QuestionnaireQuestions = new List<QuestionnaireQuestion>();
        }
    }
}
