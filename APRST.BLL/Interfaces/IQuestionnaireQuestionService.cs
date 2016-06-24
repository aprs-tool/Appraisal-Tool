using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IQuestionnaireQuestionService
    {
        void Add(QuestionnaireQuestionDTO question);
        void UpdateQuestion(QuestionnaireQuestionDTO question);
        void RemoveQuestionById(int id);
        QuestionnaireQuestionDTO GetById(int id);
    }
}
