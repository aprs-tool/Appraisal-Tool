using System;
using System.Collections.Generic;
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
    public class QuestionnaireQuestionService : IQuestionnaireQuestionService
    {
        IUnitOfWork _uow;
        public QuestionnaireQuestionService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void Add(QuestionnaireQuestionDTO question)
        {
            _uow.QuestionnaireQuestionRepository.Add(Mapper.Map<QuestionnaireQuestionDTO, QuestionnaireQuestion>(question));
            _uow.Save();
        }

        public QuestionnaireQuestionDTO GetById(int id)
        {
            return Mapper.Map<QuestionnaireQuestion, QuestionnaireQuestionDTO>(_uow.QuestionnaireQuestionRepository.GetEntityById(id));
        }

        public void RemoveQuestionById(int id)
        {
            _uow.QuestionnaireQuestionRepository.DeleteById(id);
            _uow.Save();
        }

        public void UpdateQuestion(QuestionnaireQuestionDTO question)
        {
            _uow.QuestionnaireQuestionRepository.Update(Mapper.Map<QuestionnaireQuestionDTO, QuestionnaireQuestion>(question));
            _uow.Save();
        }
    }
}
