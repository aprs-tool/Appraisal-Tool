using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.DTO
{
    public class TestAnswerDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Point { get; set; }
        public string Answer { get; set; }
    }
}
