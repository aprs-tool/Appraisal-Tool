using System.Threading.Tasks;
using APRST.DAL.Entities;

namespace APRST.DAL.Interfaces
{
    public interface IQuestionnaireCategoryRepository : IRepository<QuestionnaireCategory>
    {
        Task<QuestionnaireCategory> QuestionnaireCategoryWithQuestionsAsync(int id);
    }
}
