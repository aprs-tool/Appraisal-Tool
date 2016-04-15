using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Repositories
{
    public class TestRepository:BaseRepository<Test>,ITestRepository
    {
        public TestRepository(DbContext context):base(context)
        {
        }
    }
}
