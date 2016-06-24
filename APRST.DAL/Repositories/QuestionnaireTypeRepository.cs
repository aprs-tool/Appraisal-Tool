using System.Data.Entity;
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
