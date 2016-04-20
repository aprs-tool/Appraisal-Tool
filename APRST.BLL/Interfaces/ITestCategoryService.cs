using APRST.BLL.DTO;
using APRST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.Interfaces
{
    public interface ITestCategoryService
    {
        TestCategoryIncludeTestsDTO TestCategoryWithTests(int id);
        IEnumerable<TestCategoryDTO> GetAll();
        TestCategoryDTO GetById(int id);
        void AddCategory(TestCategoryDTO categoryDto);
        void RemoveCategoryById(int id);
        void UpdateCategory(TestCategoryDTO categoryDto);

    }
}
