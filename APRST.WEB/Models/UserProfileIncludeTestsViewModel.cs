﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class UserProfileIncludeTestsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Пользователь")]
        public string Name { get; set; }
        public string UserPrincipalName { get; set; }
        public string SamAccoutName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        public List<TestInfoViewModel> Tests { get; set; }
    }
}