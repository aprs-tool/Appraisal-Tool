using System.ComponentModel.DataAnnotations;

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
        public string UserIdentityName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public int UserRoleId { get; set; }
    }
}