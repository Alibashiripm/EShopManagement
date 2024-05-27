using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.User.Client
{
    public class ClientEditUserAvatarDto
    {
        public int UserId { get; set; }
        public string UserAvatarName { get; set; }
     
    }public class ClientEditUserPasswordDto
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
