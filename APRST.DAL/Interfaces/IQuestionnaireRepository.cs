﻿using System.Collections.Generic;
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
