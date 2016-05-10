using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Entities
{
    public class QuestionnaireType
    {
        public QuestionnaireType()
        {
            Questionnaires = new List<Questionnaire>();
        }

        public int Id { get; set; }
        public string TypeOfQuestionnaire { get; set; }
        public List<Questionnaire> Questionnaires { get; set; }
    }
}
