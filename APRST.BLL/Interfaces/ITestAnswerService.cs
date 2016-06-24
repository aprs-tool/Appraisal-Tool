using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface ITestAnswerService
    {
        void Add(TestAnswerDTO answerDTO);
        void UpdateAnswer(TestAnswerDTO answerDTO);
        void RemoveAnswerById(int id);
        TestAnswerDTO GetById(int id);
    }
}
