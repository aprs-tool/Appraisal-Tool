using APRST.DAL.EF;
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
