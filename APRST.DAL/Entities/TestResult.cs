using System;
using System.Collections.Generic;

namespace APRST.DAL.Entities
{
    public class TestResult
    {
        public TestResult()
        {
            UserProfiles = new List<UserProfile>();
        }
        public int Id { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }
        public int Point { get; set; }
        public DateTime Date { get; set; }
        public List<UserProfile> UserProfiles { get; set; }
    }
}