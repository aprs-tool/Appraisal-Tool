﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.DTO
{
    public class TestInfoDTO
    {
        public int Id { get; set; }
        public string NameOfTest { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
        public int TestCategoryId { get; set; }
    }
}
