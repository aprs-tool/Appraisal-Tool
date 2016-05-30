using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Interfaces;
using AutoMapper;
using APRST.DAL.Entities;
using System.Collections.Generic;

namespace APRST.BLL.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _uow;

        public LogService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<LogEntryDTO> GetLog()
        {
            return Mapper.Map<IEnumerable<LogEntry>, IEnumerable<LogEntryDTO>>(_uow.LogRepository.GetLog());
        }
    }
}