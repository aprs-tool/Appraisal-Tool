using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;

namespace APRST.BLL.Interfaces
{
    public interface IQuestionnaireCategoryService
    {
        //TODO: ПЕРЕДЕЛАТЬ TESTCATEGORY INCLUDE DTO
       QuestionnaireCategoryIncludeQuestionsDTO QuestionnaireCategoryWithQuestionsDTO(int id);
        IEnumerable<QuestionnaireCategoryDTO> GetAll();
        QuestionnaireCategoryDTO GetById(int id);
        void AddCategory(QuestionnaireCategoryDTO categoryDto);
        void RemoveCategoryById(int id);
        void UpdateCategory(QuestionnaireCategoryDTO categoryDto);
    }
}
