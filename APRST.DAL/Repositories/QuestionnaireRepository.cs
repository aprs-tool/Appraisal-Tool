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

        public async Task<IEnumerable<Questionnaire>> GetAllIncludeUserAndTypeAsync()
        {
            return await GetEntities().Include(user => user.UserProfile).Include(type => type.QuestionnaireType).ToListAsync();
        }

        public async Task<Questionnaire> GetIncludeResultsByUserIdAsync(int id)
        {
            return await GetEntities().Include(d=>d.QuestionnaireResults).FirstOrDefaultAsync(s => s.UserProfileId == id);
        }

        public Questionnaire GetQuestionnaireByUserId(int id)
        {
            return GetEntities().FirstOrDefault(s => s.UserProfileId == id);
        }

        public async Task<Questionnaire> GetQuestionnaireByUserIdAsync(int id)
        {
            return await GetEntities().FirstOrDefaultAsync(s => s.UserProfileId == id);
        }
    }
}
