using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace APRST.BLL.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        private readonly IUnitOfWork _uow;
        public TestQuestionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(TestQuestionDTO questionDTO)
        {
            _uow.TestQuestionRepository.Add(Mapper.Map<TestQuestionDTO, TestQuestion>(questionDTO));
            _uow.Save();
        }

        public IEnumerable<TestQuestionInfoDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<TestQuestion>, List<TestQuestionInfoDTO>>(_uow.TestQuestionRepository.GetEntities());
        }

        public TestQuestionDTO GetById(int id)
        {
            return Mapper.Map<TestQuestion, TestQuestionDTO>(_uow.TestQuestionRepository.GetEntityById(id));
        }

        public void UpdateTest(TestQuestionDTO qst)
        {
            _uow.TestQuestionRepository.Update(Mapper.Map<TestQuestionDTO, TestQuestion>(qst));
            _uow.Save();
        }

        public void RemoveQuestionById(int id)
        {
            _uow.TestQuestionRepository.DeleteById(id);
            _uow.Save();
        }

        public TestQuestionIncludeAnswersDTO GetAnswersForQuestion(int id)
        { 
            return Mapper.Map<TestQuestion, TestQuestionIncludeAnswersDTO>(_uow.TestQuestionRepository.GetAnswersForQuestion(id));
        }

        public IEnumerable<TestQuestionIncludeAnswersDTO> GetQA(int testId)
        {
            return Mapper.Map<IEnumerable<TestQuestion>, IEnumerable<TestQuestionIncludeAnswersDTO>>(_uow.TestQuestionRepository.GetQA(testId));
        }
    }
}
