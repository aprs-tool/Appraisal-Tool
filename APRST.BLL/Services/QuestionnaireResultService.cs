using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using System.Collections.Generic;
using APRST.DAL.Entities;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace APRST.BLL.Services
{
    public class QuestionnaireResultService : IQuestionnaireResultService
    {
        private readonly IUnitOfWork _uow;

        public QuestionnaireResultService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddResultAsync(List<QuestionnaireResultDTO> resultDto, int userId)
        {
            var questionnaire = _uow.QuestionnaireRepository.GetQuestionnaireByUserId(userId);
            foreach (var item in resultDto)
            {
                questionnaire.QuestionnaireResults.Add(Mapper.Map<QuestionnaireResultDTO, QuestionnaireResult>(item));
            }
            await _uow.SaveAsync();
        }

        public async Task UpdateResultAsync(List<QuestionnaireResultDTO> resultDto)
        {
            foreach (var item in resultDto)
            {
                _uow.QuestionnaireResultRepository.Update(Mapper.Map<QuestionnaireResultDTO, QuestionnaireResult>(item));
            }
            await _uow.SaveAsync();
        }
    }
}