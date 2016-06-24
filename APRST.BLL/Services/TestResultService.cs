using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using AutoMapper;
using APRST.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APRST.BLL.Services
{
    public class TestResultService : ITestResultService
    {
        private readonly IUnitOfWork _uow;

        public TestResultService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(TestResultDTO testResult, string userIdentityName)
        {
            _uow.UserProfileRepository.GetProfileWithTestsByUserIdentityName(userIdentityName).TestResults.Add(Mapper.Map<TestResultDTO, TestResult>(testResult));
            await _uow.SaveAsync();
        }

        public async Task<TestResultDTO> GetByIdAsync(int id)
        {
            return Mapper.Map<TestResult, TestResultDTO>(await _uow.TestResultRepository.GetEntityByIdAsync(id));
        }

        public async Task<List<TestResultInfoDTO>> GetUserTestsResultsAsync(int id)
        {
            return Mapper.Map<List<TestResult>, List<TestResultInfoDTO>>(await _uow.TestResultRepository.GetUserTestsResultsAsync(id));
        }

        public async Task RemoveByIdAsync(int id)
        {
            await _uow.TestResultRepository.DeleteByIdAsync(id);
            _uow.Save();
        }
    }
}