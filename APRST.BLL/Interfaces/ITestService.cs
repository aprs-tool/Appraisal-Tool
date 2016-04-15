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
        void RemoveTest(TestDTO testDto);
        void UpdateTest(TestDTO testDto);
        IEnumerable<TestDTO> GetAll();
        TestDTO GetByID(int id);
        void Dispose();
    }
}
