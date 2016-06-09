using AutoMapper;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task AddAsync(TestAnswerDTO answerDTO)
        {
            _uow.TestAnswerRepository.Add(Mapper.Map<TestAnswerDTO, TestAnswer>(answerDTO));
            await _uow.SaveAsync();
        }

        public async Task UpdateAnswerAsync(TestAnswerDTO answerDTO)
        {
            _uow.TestAnswerRepository.Update(Mapper.Map<TestAnswerDTO, TestAnswer>(answerDTO));
            await _uow.SaveAsync();
        }

        public async Task RemoveAnswerByIdAsync(int id)
        {
            await _uow.TestAnswerRepository.DeleteByIdAsync(id);
            await _uow.SaveAsync();
        }

        public async Task<TestAnswerDTO> GetByIdAsync(int id)
        { 
            return Mapper.Map<TestAnswer, TestAnswerDTO>(await _uow.TestAnswerRepository.GetEntityByIdAsync(id));
        }
    }
}
