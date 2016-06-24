using System.Collections.Generic;

namespace APRST.WEB.Models
{
    public class QuestionnaireViewModel
    {
        public int Id { get; set; }
        public int QuestionnaireTypeId { get; set; }
        public int UserProfileId { get; set; }
        public ICollection<QuestionnaireResultViewModel> QuestionnaireResults { get; set; }
    }
}