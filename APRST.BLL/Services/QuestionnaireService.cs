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
    public class QuestionnaireService:IQuestionnaireService
    {
        IUnitOfWork _uow;

        public QuestionnaireService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(QuestionnaireDTO questionnaireDto)
        {

            _uow.QuestionnaireRepository.Add(Mapper.Map<QuestionnaireDTO, Questionnaire>(questionnaireDto));
            _uow.Save();
        }

        public void RemoveById(int id)
        {
            _uow.QuestionnaireRepository.DeleteById(id);
            _uow.Save();
        }

        public void Update(QuestionnaireDTO questionnaireDto)
        {
            _uow.QuestionnaireRepository.Update(Mapper.Map<QuestionnaireDTO, Questionnaire>(questionnaireDto));
            _uow.Save();
        }

        public QuestionnaireDTO GetByUserId(int id)
        {
            return Mapper.Map<Questionnaire, QuestionnaireDTO>(_uow.QuestionnaireRepository.GetQuestionnaireByUserId(id));
        }

        public QuestionnaireDTO QuestionnaireWithResultsByUserId(int id)
        {
            return Mapper.Map<Questionnaire, QuestionnaireDTO>(_uow.QuestionnaireRepository.GetIncludeResultsByUserId(id));
        }

        public IEnumerable<QuestionnaireTypeDTO> GetAllTypesOfQuestionnaire()
        {
            return Mapper.Map<IEnumerable<QuestionnaireType>, List<QuestionnaireTypeDTO>>(_uow.QuestionnaireTypeRepository.GetEntities());
        }

        public IEnumerable<QuestionnairesDTO> GetAllIncludeUserAndType()
        {
            return Mapper.Map< IEnumerable<Questionnaire>, IEnumerable<QuestionnairesDTO>>(_uow.QuestionnaireRepository.GetAllIncludeUserAndType());
        }
    }
}
