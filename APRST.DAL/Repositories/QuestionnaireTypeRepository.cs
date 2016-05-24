using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;

namespace APRST.DAL.Repositories
{
    public class QuestionnaireTypeRepository: BaseRepository<QuestionnaireType>,IQuestionnaireTypeRepository
    {
        public QuestionnaireTypeRepository(DbContext context):base(context)
        {
        }
    }
}
