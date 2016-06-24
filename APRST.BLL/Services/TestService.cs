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
        public void AddTest(TestDTO testDto)
        {
            _uow.TestRepository.Add(Mapper.Map<TestDTO, Test>(testDto));
            _uow.Save();
        }

        public void RemoveTestById(int id)
        {
            _uow.TestRepository.DeleteById(id);
            _uow.Save();
        }

        public void UpdateTest(TestDTO testDto)
        {
            _uow.TestRepository.Update(Mapper.Map<TestDTO, Test>(testDto));
            _uow.Save();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestInfoDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Test>, List<TestInfoDTO>>(_uow.TestRepository.TestWithCategory());
        }

        public TestDTO GetById(int id)
        {
            return Mapper.Map<Test, TestDTO>(_uow.TestRepository.GetEntityById(id));   
        }

        public IEnumerable<TestDTO> GetTestsByCategoryId(int id)
        {
            return Mapper.Map<IEnumerable<Test>, List<TestDTO>>(_uow.TestRepository.GetTestByCategoryId(id));  
        }

        public TestIncludeQuestionsDTO GetQuestionsForTest(int id)
        {
            return Mapper.Map<Test, TestIncludeQuestionsDTO>(_uow.TestRepository.GetQuestionsForTest(id));
        }

        public int GetCount()
        {
            return _uow.TestRepository.GetCount();
        }
    }
}
