using System.Collections.Generic;

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
