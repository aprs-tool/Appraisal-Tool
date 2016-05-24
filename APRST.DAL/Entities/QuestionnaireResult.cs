using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Entities
{
    public class QuestionnaireResult
    {
        public QuestionnaireResult()
        {
            Questionnaires = new List<Questionnaire>();
        }

        public int Id { get; set; }
        public int QuestionnaireQuestionId { get; set; }
        public QuestionnaireQuestion QuestionnaireQuestion { get; set; }
        public int Answer { get; set; }
        public ICollection<Questionnaire> Questionnaires { get; set; }
    }
}
