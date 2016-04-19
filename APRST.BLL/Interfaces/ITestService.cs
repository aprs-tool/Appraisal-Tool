using APRST.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.Interfaces
{
    public interface ITestService
    {
        void AddTest(TestDTO testDto);
        void RemoveTestById(int id);
        void UpdateTest(TestDTO testDto);
        IEnumerable<TestInfoDTO> GetAll();
        TestDTO GetById(int id);
        IEnumerable<TestDTO> GetTestByCategoryId(int id);
        void Dispose();
    }
}
