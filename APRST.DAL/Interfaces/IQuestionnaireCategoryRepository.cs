using APRST.DAL.Entities;

namespace APRST.DAL.Interfaces
{
    public interface IQuestionnaireCategoryRepository : IRepository<QuestionnaireCategory>
    {
        QuestionnaireCategory QuestionnaireCategoryWithQuestions(int id);
    }
}
