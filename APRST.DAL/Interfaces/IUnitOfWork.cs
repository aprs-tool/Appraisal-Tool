﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ITestRepository TestRepository { get; }
        ITestCategoryRepository TestCategoryRepository { get; }
        ITestQuestionRepository TestQuestionRepository { get; }
        ITestAnswerRepository TestAnswerRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        void Save();
    }
}
