using APRST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using APRST.BLL.DTO;
using APRST.DAL.Interfaces;
using APRST.DAL.Entities;
using AutoMapper;

namespace APRST.BLL.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _uow;

        public TestService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<TestInfoDTO>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<Test>, List<TestInfoDTO>>(await _uow.TestRepository.TestWithCategoryAsync());
        }

        public async Task<TestDTO> GetByIdAsync(int id)
        {
            return Mapper.Map<Test, TestDTO>( await _uow.TestRepository.GetEntityByIdAsync(id));   
        }

        public async Task<IEnumerable<TestDTO>> GetTestsByCategoryIdAsync(int id)
        {
            return Mapper.Map<IEnumerable<Test>, List<TestDTO>>(await _uow.TestRepository.GetTestByCategoryIdAsync(id));  
        }

        public async Task<TestIncludeQuestionsDTO> GetQuestionsForTestAsync(int id)
        {
            return Mapper.Map<Test, TestIncludeQuestionsDTO>(await _uow.TestRepository.GetQuestionsForTestAsync(id));
        }

        public async Task AddTestAsync(TestDTO testDto)
        {
            _uow.TestRepository.Add(Mapper.Map<TestDTO, Test>(testDto));
            await _uow.SaveAsync();
        }

        public async Task RemoveTestByIdAsync(int id)
        {
            await _uow.TestRepository.DeleteByIdAsync(id);
            await _uow.SaveAsync();
        }

        public async Task UpdateTestAsync(TestDTO testDto)
        {
            _uow.TestRepository.Update(Mapper.Map<TestDTO, Test>(testDto));
            await _uow.SaveAsync();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            return _uow.TestRepository.GetCount();
        }
    }
}
