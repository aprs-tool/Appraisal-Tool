﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class TestInfoViewModel
    {
        public int Id { get; set; }
        public string NameOfTest { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
        public int TestCategoryId { get; set; }
    }
}