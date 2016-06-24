using System.Collections.Generic;
using APRST.DAL.Entities;

namespace APRST.DAL.Interfaces
{
    public interface IQuestionnaireRepository:IRepository<Questionnaire>
    {
        Questionnaire GetQuestionnaireByUserId(int id);
        Task<Questionnaire> GetQuestionnaireByUserIdAsync(int id);
        Task<Questionnaire> GetIncludeResultsByUserIdAsync(int id);
        Task<IEnumerable<Questionnaire>> GetAllIncludeUserAndTypeAsync();
    }
}
