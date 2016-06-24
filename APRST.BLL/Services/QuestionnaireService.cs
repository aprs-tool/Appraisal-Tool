using System.Collections.Generic;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using AutoMapper;

namespace APRST.BLL.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IUnitOfWork _uow;

        public QuestionnaireService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(QuestionnaireDTO questionnaireDto)
        {
            _uow.QuestionnaireRepository.Add(Mapper.Map<QuestionnaireDTO, Questionnaire>(questionnaireDto));
            await _uow.SaveAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            _uow.QuestionnaireRepository.DeleteById(id);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsync(QuestionnaireDTO questionnaireDto)
        {
            _uow.QuestionnaireRepository.Update(Mapper.Map<QuestionnaireDTO, Questionnaire>(questionnaireDto));
            await _uow.SaveAsync();
        }

        public async Task<QuestionnaireDTO> GetByUserIdAsync(int id)
        {
            return Mapper.Map<Questionnaire, QuestionnaireDTO>(await _uow.QuestionnaireRepository.GetQuestionnaireByUserIdAsync(id));
        }

        public async Task<QuestionnaireDTO> QuestionnaireWithResultsByUserIdAsync(int id)
        {
            return Mapper.Map<Questionnaire, QuestionnaireDTO>(await _uow.QuestionnaireRepository.GetIncludeResultsByUserIdAsync(id));
        }

        public async Task<IEnumerable<QuestionnaireTypeDTO>> GetAllTypesOfQuestionnaireAsync()
        {
            return Mapper.Map<IEnumerable<QuestionnaireType>, List<QuestionnaireTypeDTO>>(await _uow.QuestionnaireTypeRepository.GetAllAsync());
        }

        public async Task<IEnumerable<QuestionnairesDTO>> GetAllIncludeUserAndTypeAsync()
        {
            return Mapper.Map<IEnumerable<Questionnaire>, IEnumerable<QuestionnairesDTO>>(await _uow.QuestionnaireRepository.GetAllIncludeUserAndTypeAsync());
        }

        public int GetCount()
        {
            return _uow.QuestionnaireRepository.GetCount();
        }
    }
}
