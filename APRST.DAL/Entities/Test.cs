﻿using System.Collections.Generic;

namespace APRST.DAL.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string NameOfTest { get; set; }
        public string Desc { get; set; }
        public int? TestCategoryId { get; set; }
        public TestCategory TestCategory { get; set; }

        public ICollection<TestQuestion> Questions { get; set; }
        public ICollection<TestResult> Results { get; set; }
        public List<UserProfile> UserProfiles { get; set; }
        public Test()
        {
            UserProfiles = new List<UserProfile>();
            Questions = new List<TestQuestion>();
            Results = new List<TestResult>();
        }
    }
}
