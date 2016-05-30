using APRST.DAL.Entities;
using System.Collections.Generic;

namespace APRST.DAL.Interfaces
{
    public interface ILogRepository : IRepository<LogEntry>
    {
        IEnumerable<LogEntry> GetLog();
    }
}