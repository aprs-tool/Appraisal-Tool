using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace APRST.DAL.Repositories
{
    public class LogRepository : BaseRepository<LogEntry>, ILogRepository
    {
        public LogRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<LogEntry> GetLog()
        {
            return GetEntities();
        }
    }
}