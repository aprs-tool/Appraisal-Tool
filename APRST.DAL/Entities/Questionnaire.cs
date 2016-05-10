using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Entities
{
    public class Questionnaire
    {
        public Questionnaire()
        {
            QuestionnaireResults = new List<QuestionnaireResult>();
        }

        public int Id { get; set; }
        public int QuestionnaireTypeId { get; set; }
        public QuestionnaireType QuestionnaireType { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<QuestionnaireResult> QuestionnaireResults { get; set; }
    }
}
