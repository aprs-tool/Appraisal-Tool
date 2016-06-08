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
        Task<TestCategoryIncludeTestsDTO> TestCategoryWithTestsAsync(int id);
        Task<IEnumerable<TestCategoryDTO>> GetAllAsync();
        Task<TestCategoryDTO> GetByIdAsync(int id);
        Task AddCategoryAsync(TestCategoryDTO categoryDto);
        Task RemoveCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(TestCategoryDTO categoryDto);

    }
}
