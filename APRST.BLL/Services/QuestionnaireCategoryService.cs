using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using AutoMapper;

namespace APRST.BLL.Services
{
    public class QuestionnaireCategoryService : IQuestionnaireCategoryService
    {
        IUnitOfWork _uow;

        public QuestionnaireCategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddCategoryAsync(QuestionnaireCategoryDTO categoryDto)
        {
            _uow.QuestionnaireCategoryRepository.Add(Mapper.Map<QuestionnaireCategoryDTO, QuestionnaireCategory>(categoryDto));
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<QuestionnaireCategoryDTO>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<QuestionnaireCategory>, List<QuestionnaireCategoryDTO>>(await _uow.QuestionnaireCategoryRepository.GetAllAsync());
        }

        public async Task<IEnumerable<QuestionnaireCategoryIncludeQuestionsDTO>> GetAllWithQuestionsAsync()
        {
            return Mapper.Map<IEnumerable<QuestionnaireCategory>, List<QuestionnaireCategoryIncludeQuestionsDTO>>(await _uow.QuestionnaireCategoryRepository.GetEntities().Include(S=>S.QuestionnaireQuestions).ToListAsync());
        }

        public async Task<QuestionnaireCategoryDTO> GetByIdAsync(int id)
        {
            return Mapper.Map<QuestionnaireCategory, QuestionnaireCategoryDTO>(await _uow.QuestionnaireCategoryRepository.GetEntityByIdAsync(id));
        }

        public async Task<QuestionnaireCategoryIncludeQuestionsDTO> QuestionnaireCategoryWithQuestionsDTOAsync(int id)
        {
            return Mapper.Map<QuestionnaireCategory, QuestionnaireCategoryIncludeQuestionsDTO>(await _uow.QuestionnaireCategoryRepository.QuestionnaireCategoryWithQuestionsAsync(id));
        }

        public async Task RemoveCategoryByIdAsync(int id)
        {
            await _uow.QuestionnaireCategoryRepository.DeleteByIdAsync(id);
            await _uow.SaveAsync();
        }

        public async Task UpdateCategoryAsync(QuestionnaireCategoryDTO categoryDto)
        {
            _uow.QuestionnaireCategoryRepository.Update(Mapper.Map<QuestionnaireCategoryDTO, QuestionnaireCategory>(categoryDto));
            await _uow.SaveAsync();
        }
    }
}
