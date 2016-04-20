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
        IUnitOfWork _uow;
        public TestCategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddCategory(TestCategoryDTO categoryDto)
        {
            Mapper.CreateMap<TestCategoryDTO, TestCategory>();
            _uow.TestCategoryRepository.Add(Mapper.Map<TestCategoryDTO, TestCategory>(categoryDto));
            _uow.Save();
        }

        public IEnumerable<TestCategoryDTO> GetAll()
        {
            Mapper.CreateMap<TestCategory, TestCategoryDTO>();
            return Mapper.Map<IEnumerable<TestCategory>,List<TestCategoryDTO>>(_uow.TestCategoryRepository.GetEntities());
        }

        public TestCategoryDTO GetById(int id)
        {
            Mapper.CreateMap<TestCategory, TestCategoryDTO>();
            return Mapper.Map<TestCategory, TestCategoryDTO>(_uow.TestCategoryRepository.GetEntityById(id));
        }

        public void RemoveCategoryById(int id)
        {
            _uow.TestCategoryRepository.DeleteById(id);
            _uow.Save();
        }

        public TestCategoryIncludeTestsDTO TestCategoryWithTests(int id)
        {
            Mapper.CreateMap<Test, TestDTO>();
            Mapper.CreateMap<TestCategory, TestCategoryIncludeTestsDTO>()
                .ForMember(dto => dto.TestDtos, opt => opt.MapFrom(src => src.Tests));
            return Mapper.Map<TestCategory, TestCategoryIncludeTestsDTO>(_uow.TestCategoryRepository.TestCategoryWithTests(id));
        }

        public void UpdateCategory(TestCategoryDTO categoryDto)
        {
            Mapper.CreateMap<TestCategoryDTO, TestCategory>();
            _uow.TestCategoryRepository.Update(Mapper.Map<TestCategoryDTO, TestCategory>(categoryDto));
            _uow.Save();
        }
    }
}
