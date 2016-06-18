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
        public async Task AddAsync(QuestionnaireQuestionDTO question)
        {
            _uow.QuestionnaireQuestionRepository.Add(Mapper.Map<QuestionnaireQuestionDTO, QuestionnaireQuestion>(question));
            await _uow.SaveAsync();
        }

        public async Task<QuestionnaireQuestionDTO> GetByIdAsync(int id)
        {
            return Mapper.Map<QuestionnaireQuestion, QuestionnaireQuestionDTO>(await _uow.QuestionnaireQuestionRepository.GetEntityByIdAsync(id));
        }

        public async Task RemoveQuestionByIdAsync(int id)
        {
            _uow.QuestionnaireQuestionRepository.DeleteById(id);
            await _uow.SaveAsync();
        }

        public async Task UpdateQuestionAsync(QuestionnaireQuestionDTO question)
        {
            _uow.QuestionnaireQuestionRepository.Update(Mapper.Map<QuestionnaireQuestionDTO, QuestionnaireQuestion>(question));
            await _uow.SaveAsync();
        }
    }
}
