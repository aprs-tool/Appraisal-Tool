using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace APRST.DAL.Entities
{
    public class LogEntry
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
    }
}
