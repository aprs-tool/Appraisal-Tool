using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        IUnitOfWork _uow;
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

        public void RemoveTestById(int id)
        {
            _uow.TestQuestionRepository.DeleteById(id);
            _uow.Save();
        }

        public TestQuestionIncludeAnswersDTO GetAnswersForQuestion(int id)
        { 
            return Mapper.Map<TestQuestion, TestQuestionIncludeAnswersDTO>(_uow.TestQuestionRepository.GetAnswersForQuestion(id));
        }
    }
}
