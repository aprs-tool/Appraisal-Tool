using System.Data.Entity;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;

namespace APRST.DAL.Repositories
{
    public class QuestionnaireQuestionRepository:BaseRepository<QuestionnaireQuestion>,IQuestionnaireQuestionRepository
    {
        public QuestionnaireQuestionRepository(DbContext context) : base(context)
        {
        }
    }
}
