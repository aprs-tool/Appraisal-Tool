using System.Collections.Generic;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IQuestionnaireCategoryService
    {
        //TODO: ПЕРЕДЕЛАТЬ TESTCATEGORY INCLUDE DTO
        Task<QuestionnaireCategoryIncludeQuestionsDTO> QuestionnaireCategoryWithQuestionsDTOAsync(int id);
        Task<IEnumerable<QuestionnaireCategoryDTO>> GetAllAsync();
        Task<QuestionnaireCategoryDTO> GetByIdAsync(int id);
        Task AddCategoryAsync(QuestionnaireCategoryDTO categoryDto);
        Task RemoveCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(QuestionnaireCategoryDTO categoryDto);
        Task<IEnumerable<QuestionnaireCategoryIncludeQuestionsDTO>> GetAllWithQuestionsAsync();
    }
}
