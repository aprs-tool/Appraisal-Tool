using APRST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Interfaces
{
    public interface ITestRepository:IRepository<Test>
    {
        IEnumerable<Test> TestWithCategory();
        IEnumerable<Test> GetByIdWithCategory(int id);
        IEnumerable<Test> GetTestByCategoryId(int id);
    }
}
