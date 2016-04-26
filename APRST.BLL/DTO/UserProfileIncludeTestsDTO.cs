﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.DTO
{
    public class UserProfileIncludeTestsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserPrincipalName { get; set; }
        public string SamAccoutName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<TestInfoDTO> Tests { get; set; }
    }
}
