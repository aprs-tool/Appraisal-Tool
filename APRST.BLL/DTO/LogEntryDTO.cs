using System;

namespace APRST.BLL.DTO
{
    public class LogEntryDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
    }
}