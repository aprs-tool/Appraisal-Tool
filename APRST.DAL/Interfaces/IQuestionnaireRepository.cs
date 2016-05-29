using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.DAL.Entities;

namespace APRST.DAL.Interfaces
{
    public interface IQuestionnaireRepository:IRepository<Questionnaire>
    {
        Questionnaire GetQuestionnaireByUserId(int id);
        Questionnaire GetIncludeResultsByUserId(int id);
        IEnumerable<Questionnaire> GetAllIncludeUserAndType();
    }
}
