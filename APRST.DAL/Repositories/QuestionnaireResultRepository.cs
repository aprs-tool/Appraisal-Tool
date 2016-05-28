﻿using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Data.Entity;

namespace APRST.DAL.Repositories
{
    public class QuestionnaireResultRepository : BaseRepository<QuestionnaireResult>, IQuestionnaireResultRepository
    {
        public QuestionnaireResultRepository(DbContext context) : base(context)
        {
        }
    }
}