using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.DTO
{
    public class QuestionnaireResultDTO
    {
        public int Id { get; set; }
        public int QuestionnaireQuestionId { get; set; }
        public int Answer { get; set; }
    }
}
