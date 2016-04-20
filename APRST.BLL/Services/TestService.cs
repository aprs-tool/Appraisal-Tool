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
        }

        public void RemoveTestById(int id)
        {
            _uow.TestRepository.DeleteById(id);
            _uow.Save();
        }

        public void UpdateTest(TestDTO testDto)
        {
            Mapper.CreateMap<TestDTO, Test>();
            _uow.TestRepository.Update(Mapper.Map<TestDTO, Test>(testDto));
            _uow.Save();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestInfoDTO> GetAll()
        {
            Mapper.CreateMap<Test, TestInfoDTO>()
                .ForMember("Category", opt => opt.MapFrom(src => src.TestCategory.NameOfCategory));
            return Mapper.Map<IEnumerable<Test>, List<TestInfoDTO>>(_uow.TestRepository.TestWithCategory());
        }

        public TestDTO GetById(int id)
        {
            Mapper.CreateMap<Test, TestDTO>();
                return Mapper.Map<Test, TestDTO>(_uow.TestRepository.GetEntityById(id));   
        }

        public IEnumerable<TestDTO> GetTestsByCategoryId(int id)
        {
            Mapper.CreateMap<Test, TestDTO>();
            return Mapper.Map<IEnumerable<Test>, List<TestDTO>>(_uow.TestRepository.GetTestByCategoryId(id));
            
        }
    }
}
