using AutoMapper;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using APRST.BLL.DTO;
using APRST.DAL.Entities;

namespace APRST.BLL.Services
{
    public class TestAnswerService : ITestAnswerService
    {
        private readonly IUnitOfWork _uow;

        public TestAnswerService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(TestAnswerDTO answerDTO)
        {
            _uow.TestAnswerRepository.Add(Mapper.Map<TestAnswerDTO, TestAnswer>(answerDTO));
            _uow.Save();
        }

        public void UpdateAnswer(TestAnswerDTO answerDTO)
        {
            _uow.TestAnswerRepository.Update(Mapper.Map<TestAnswerDTO, TestAnswer>(answerDTO));
            _uow.Save();
        }

        public void RemoveAnswerById(int id)
        {
            _uow.TestAnswerRepository.DeleteById(id);
            _uow.Save();
        }

        public TestAnswerDTO GetById(int id)
        { 
            return Mapper.Map<TestAnswer, TestAnswerDTO>(_uow.TestAnswerRepository.GetEntityById(id));
        }
    }
}
