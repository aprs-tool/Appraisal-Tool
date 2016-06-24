using System.Collections.Generic;

namespace APRST.DAL.Entities
{
    public class UserRole
    {
        public UserRole()
        {
            UserProfiles = new List<UserProfile>();
        }
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<UserProfile> UserProfiles { get; set; }

    }
}
