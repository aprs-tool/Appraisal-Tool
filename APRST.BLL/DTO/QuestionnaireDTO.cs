using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
