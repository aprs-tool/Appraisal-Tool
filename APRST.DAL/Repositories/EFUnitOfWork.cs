﻿using APRST.DAL.EF;
using APRST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AprstContext db;
        private ITestRepository testRepository;
        private ITestCategoryRepository testCategoryRepository;
        private ITestQuestionRepository testQuestionRepository;
        private ITestAnswerRepository testAnswerRepository;
        private ITestResultRepository _testResultRepository;
        private IUserProfileRepository userProfileRepository;
        private IRoleRepository roleRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new AprstContext(connectionString);
        }
        public ITestRepository TestRepository
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(db);
                return testRepository;
            }
        }
        public ITestCategoryRepository TestCategoryRepository
        {
            get
            {
                if (testCategoryRepository == null)
                    testCategoryRepository = new TestCategoryRepository(db);
                return testCategoryRepository;
            }
        }

        public ITestQuestionRepository TestQuestionRepository
        {
            get
            {
                if (testQuestionRepository == null)
                    testQuestionRepository = new TestQuestionRepository(db);
                return testQuestionRepository;
            }
        }

        public ITestAnswerRepository TestAnswerRepository
        {
            get
            {
                if (testAnswerRepository == null)
                    testAnswerRepository = new TestAnswerRepository(db);
                return testAnswerRepository;
            }
        }

        public ITestResultRepository TestResultRepository => _testResultRepository ?? (_testResultRepository = new TestResultRepository(db));

        public IUserProfileRepository UserProfileRepository
        {
            get
            {
                if (userProfileRepository == null)
                    userProfileRepository = new UserProfileRepository(db);
                return userProfileRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
