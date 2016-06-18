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
    public class QuestionnaireCategoryRepository : BaseRepository<QuestionnaireCategory>, IQuestionnaireCategoryRepository
    {
        public QuestionnaireCategoryRepository(DbContext context) : base(context)
        {
        }
        public async Task<QuestionnaireCategory> QuestionnaireCategoryWithQuestionsAsync(int id)
        {
            return await GetEntities().Where(s => s.Id == id).Include(model=>model.QuestionnaireQuestions).FirstOrDefaultAsync();
        }
    }
}
