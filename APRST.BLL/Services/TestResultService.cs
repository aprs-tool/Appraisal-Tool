using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using AutoMapper;
using APRST.DAL.Entities;
using System.Collections.Generic;

namespace APRST.BLL.Services
{
    public class TestResultService : ITestResultService
    {
        private readonly IUnitOfWork _uow;

        public TestResultService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(TestResultDTO testResult, string userIdentityName)
        {
            _uow.UserProfileRepository.GetProfileWithTestsByUserIdentityName(userIdentityName).TestResults.Add(Mapper.Map<TestResultDTO, TestResult>(testResult));
            _uow.Save();
        }

        public TestResultDTO GetById(int id)
        {
            return Mapper.Map<TestResult, TestResultDTO>(_uow.TestResultRepository.GetEntityById(id));
        }

        public List<TestResultInfoDTO> GetUserTestsResults(int id)
        {
            return
                Mapper.Map<List<TestResult>, List<TestResultInfoDTO>>(
                    _uow.TestResultRepository.GetUserTestsResults(id));
        }

        public void RemoveById(int id)
        {
            _uow.TestResultRepository.DeleteById(id);
            _uow.Save();
        }
    }
}