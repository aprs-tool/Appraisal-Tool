using System.Collections.Generic;
using System.Data.Entity;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using AutoMapper;

namespace APRST.BLL.Services
{
    public class QuestionnaireCategoryService : IQuestionnaireCategoryService
    {
        private readonly IUnitOfWork _uow;

        public QuestionnaireCategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddCategory(QuestionnaireCategoryDTO categoryDto)
        {
            _uow.QuestionnaireCategoryRepository.Add(Mapper.Map<QuestionnaireCategoryDTO, QuestionnaireCategory>(categoryDto));
            _uow.Save();
        }

        public IEnumerable<QuestionnaireCategoryDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<QuestionnaireCategory>, List<QuestionnaireCategoryDTO>>(_uow.QuestionnaireCategoryRepository.GetEntities());
        }

        public IEnumerable<QuestionnaireCategoryIncludeQuestionsDTO> GetAllWithQuestions()
        {
            return Mapper.Map<IEnumerable<QuestionnaireCategory>, List<QuestionnaireCategoryIncludeQuestionsDTO>>(_uow.QuestionnaireCategoryRepository.GetEntities().Include(s => s.QuestionnaireQuestions));
        }

        public QuestionnaireCategoryDTO GetById(int id)
        {
            return Mapper.Map<QuestionnaireCategory, QuestionnaireCategoryDTO>(_uow.QuestionnaireCategoryRepository.GetEntityById(id));
        }

        public QuestionnaireCategoryIncludeQuestionsDTO QuestionnaireCategoryWithQuestionsDTO(int id)
        {
            return Mapper.Map<QuestionnaireCategory, QuestionnaireCategoryIncludeQuestionsDTO>(_uow.QuestionnaireCategoryRepository.QuestionnaireCategoryWithQuestions(id));
        }

        public void RemoveCategoryById(int id)
        {
            _uow.QuestionnaireCategoryRepository.DeleteById(id);
            _uow.Save();
        }

        public void UpdateCategory(QuestionnaireCategoryDTO categoryDto)
        {
            _uow.QuestionnaireCategoryRepository.Update(Mapper.Map<QuestionnaireCategoryDTO, QuestionnaireCategory>(categoryDto));
            _uow.Save();
        }
    }
}
