using APRST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Interfaces
{
    public interface ITestCategoryRepository:IRepository<TestCategory>
    {
        IEnumerable<TestCategory> CategoryWithTests();
    }
}
