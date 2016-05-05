using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Пользователь")]
        public string Name { get; set; }
        [Display(Name = "Имя участника-пользователя")]
        public string UserPrincipalName { get; set; }
        [Display(Name = "Логин в AD")]
        public string SamAccoutName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
    }
}