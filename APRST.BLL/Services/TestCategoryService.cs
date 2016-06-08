using APRST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using AutoMapper;
using APRST.BLL.DTO;

namespace APRST.BLL.Services
{
    public class TestCategoryService : ITestCategoryService
    {
        private readonly IUnitOfWork _uow;
        public TestCategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddCategoryAsync(TestCategoryDTO categoryDto)
        {
            _uow.TestCategoryRepository.Add(Mapper.Map<TestCategoryDTO, TestCategory>(categoryDto));
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<TestCategoryDTO>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<TestCategory>,List<TestCategoryDTO>>(await _uow.TestCategoryRepository.GetAllAsync());
        }

        public async Task<TestCategoryDTO> GetByIdAsync(int id)
        {
            return Mapper.Map<TestCategory, TestCategoryDTO>(await _uow.TestCategoryRepository.GetEntityByIdAsync(id));
        }

        public async Task RemoveCategoryByIdAsync(int id)
        {
            await _uow.TestCategoryRepository.DeleteByIdAsync(id);
            await _uow.SaveAsync();
        }

        public async Task<TestCategoryIncludeTestsDTO> TestCategoryWithTestsAsync(int id)
        {
            return Mapper.Map<TestCategory, TestCategoryIncludeTestsDTO>(await _uow.TestCategoryRepository.TestCategoryWithTestsAsync(id));
        }

        public async Task UpdateCategoryAsync(TestCategoryDTO categoryDto)
        {
            _uow.TestCategoryRepository.Update(Mapper.Map<TestCategoryDTO, TestCategory>(categoryDto));
            await _uow.SaveAsync();
        }
    }
}
