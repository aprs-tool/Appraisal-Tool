using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
