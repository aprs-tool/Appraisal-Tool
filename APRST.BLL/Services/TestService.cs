using APRST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using APRST.DAL.Interfaces;
using APRST.DAL.Entities;

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
            _uow.TestRepository.Add(new Test { NameOfTest = testDto.NameOfTest, Desc = testDto.Desc });
            _uow.Save();
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
            throw new NotImplementedException();
        }

        public TestDTO GetByID(int id)
        {
            Test test =_uow.TestRepository.GetEntityById(id);
            return new TestDTO {Id = test.Id, NameOfTest = test.NameOfTest, Desc = test.Desc};
        }
    }
}
