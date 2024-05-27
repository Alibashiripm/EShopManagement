using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.User.Admin
{
    public class AdminUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
         public bool IsDelete { get; set; }
        public string UserAvatarName { get; set; }
        public bool IsPremiumMember { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
    }  
}
