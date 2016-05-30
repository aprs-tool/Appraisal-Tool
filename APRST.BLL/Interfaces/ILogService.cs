using APRST.BLL.DTO;
using System.Collections.Generic;

namespace APRST.BLL.Interfaces
{
    public interface ILogService
    {
        IEnumerable<LogEntryDTO> GetLog();
    }
}