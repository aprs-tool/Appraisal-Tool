using APRST.BLL.Interfaces;
using System.Collections.Generic;
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

        public void AddCategory(TestCategoryDTO categoryDto)
        {
            _uow.TestCategoryRepository.Add(Mapper.Map<TestCategoryDTO, TestCategory>(categoryDto));
            _uow.Save();
        }

        public IEnumerable<TestCategoryDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<TestCategory>,List<TestCategoryDTO>>(_uow.TestCategoryRepository.GetEntities());
        }

        public TestCategoryDTO GetById(int id)
        {
            return Mapper.Map<TestCategory, TestCategoryDTO>(_uow.TestCategoryRepository.GetEntityById(id));
        }

        public void RemoveCategoryById(int id)
        {
            _uow.TestCategoryRepository.DeleteById(id);
            _uow.Save();
        }

        public TestCategoryIncludeTestsDTO TestCategoryWithTests(int id)
        {
            return Mapper.Map<TestCategory, TestCategoryIncludeTestsDTO>(_uow.TestCategoryRepository.TestCategoryWithTests(id));
        }

        public void UpdateCategory(TestCategoryDTO categoryDto)
        {
            _uow.TestCategoryRepository.Update(Mapper.Map<TestCategoryDTO, TestCategory>(categoryDto));
            _uow.Save();
        }
    }
}
