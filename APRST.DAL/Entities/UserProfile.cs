using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            Tests=new List<Test>();
            TestResults = new List<TestResult>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserPrincipalName { get; set; }
        public string SamAccoutName { get; set; }
        public string  UserIdentityName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Test> Tests { get; set; }
        public int? UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
