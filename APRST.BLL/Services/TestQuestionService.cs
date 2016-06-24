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

        public async Task AddAsync(TestQuestionDTO questionDTO)
        {
            _uow.TestQuestionRepository.Add(Mapper.Map<TestQuestionDTO, TestQuestion>(questionDTO));
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<TestQuestionInfoDTO>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<TestQuestion>, List<TestQuestionInfoDTO>>(await _uow.TestQuestionRepository.GetAllAsync());
        }

        public async Task<TestQuestionDTO> GetByIdAsync(int id)
        {
            return Mapper.Map<TestQuestion, TestQuestionDTO>(await _uow.TestQuestionRepository.GetEntityByIdAsync(id));
        }

        public async Task UpdateTestAsync(TestQuestionDTO qst)
        {
            _uow.TestQuestionRepository.Update(Mapper.Map<TestQuestionDTO, TestQuestion>(qst));
            await _uow.SaveAsync();
        }

        public async Task RemoveTestByIdAsync(int id)
        {
            _uow.TestQuestionRepository.DeleteById(id);
            await _uow.SaveAsync();
        }

        public async Task<TestQuestionIncludeAnswersDTO> GetAnswersForQuestionAsync(int id)
        { 
            return Mapper.Map<TestQuestion, TestQuestionIncludeAnswersDTO>(await _uow.TestQuestionRepository.GetAnswersForQuestionAsync(id));
        }

        public async Task<IEnumerable<TestQuestionIncludeAnswersDTO>> GetQAAsync(int testId)
        {
            return Mapper.Map<IEnumerable<TestQuestion>, IEnumerable<TestQuestionIncludeAnswersDTO>>(await _uow.TestQuestionRepository.GetQAAsync(testId));
        }
    }
}
