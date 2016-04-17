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

        public IEnumerable<TestCategoryDTO> GetAll()
        {
            Mapper.CreateMap<TestCategory, TestCategoryDTO>();
            return Mapper.Map<IEnumerable<TestCategory>,List<TestCategoryDTO>>(_uow.TestCategoryRepository.GetEntities());
        }
    }
}
