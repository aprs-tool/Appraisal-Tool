using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using System.Collections.Generic;
using APRST.DAL.Entities;
using AutoMapper;

namespace APRST.BLL.Services
{
    public class QuestionnaireResultService : IQuestionnaireResultService
    {
        private readonly IUnitOfWork _uow;

        public QuestionnaireResultService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddResult(List<QuestionnaireResultDTO> resultDto, int userId)
        {
            foreach (var item in resultDto)
            {
                _uow.QuestionnaireRepository.GetQuestionnaireByUserId(userId).QuestionnaireResults.Add(Mapper.Map<QuestionnaireResultDTO, QuestionnaireResult>(item));
            }
            _uow.Save();
        }

        public void UpdateResult(List<QuestionnaireResultDTO> resultDto)
        {
            foreach (var item in resultDto)
            {
                _uow.QuestionnaireResultRepository.Update(Mapper.Map<QuestionnaireResultDTO, QuestionnaireResult>(item));
            }
            _uow.Save();
        }
    }
}