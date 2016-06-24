using APRST.BLL.DTO;
using System.Collections.Generic;

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
