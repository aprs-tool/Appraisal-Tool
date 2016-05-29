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
    public class QuestionnaireRepository : BaseRepository<Questionnaire>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Questionnaire> GetAllIncludeUserAndType()
        {
            return GetEntities().Include(user => user.UserProfile).Include(type => type.QuestionnaireType);
        }

        public Questionnaire GetIncludeResultsByUserId(int id)
        {
            return GetEntities().Include(d=>d.QuestionnaireResults).FirstOrDefault(s => s.UserProfileId == id);
        }

        public Questionnaire GetQuestionnaireByUserId(int id)
        {
            return GetEntities().FirstOrDefault(s => s.UserProfileId == id);
        }
    }
}
