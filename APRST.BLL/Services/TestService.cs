using APRST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using APRST.DAL.Interfaces;
using APRST.DAL.Entities;
using AutoMapper;

namespace APRST.BLL.Services
{
    public class TestService : ITestService
    {
        IUnitOfWork _uow;

        public TestService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void AddTest(TestDTO testDto)
        {
            Mapper.CreateMap<TestDTO, Test>();
            _uow.TestRepository.Add(Mapper.Map<TestDTO, Test>(testDto));
            _uow.Save();
            //_uow.TestRepository.Add(new Test { NameOfTest = testDto.NameOfTest, Desc = testDto.Desc, TestCategoryId = testDto.TestCategoryId });
            //_uow.Save();
        }

        public void RemoveTest(TestDTO testDto)
        {
            throw new NotImplementedException();
        }

        public void UpdateTest(TestDTO testDto)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestDTO> GetAll()
        {
            Mapper.CreateMap<Test, TestDTO>()
                .ForMember("Category", opt => opt.MapFrom(src => src.TestCategory.NameOfCategory));
            return Mapper.Map<IEnumerable<Test>, List<TestDTO>>(_uow.TestRepository.TestWithCategory());
        }
    }
}
