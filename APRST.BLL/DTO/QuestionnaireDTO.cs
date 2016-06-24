using System.Collections.Generic;

namespace APRST.BLL.DTO
{
    public class QuestionnaireDTO
    {
        public int Id { get; set; }
        public int QuestionnaireTypeId { get; set; }
        public int UserProfileId { get; set; }
        public ICollection<QuestionnaireResultDTO> QuestionnaireResults { get; set; }
    }
}