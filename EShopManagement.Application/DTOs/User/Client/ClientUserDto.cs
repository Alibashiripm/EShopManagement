using EShopManagement.Application.DTOs.Product.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.User.Client
{
    public class ClientUserDto
    {
        public string UserName{ get; set; }
        public string Email{ get; set; }
        public string RegistrationDate { get; set; }
        public bool IsPremiumMember { get; set; }
        public string? PremiumExpireDate { get; set; }
        public string UserAvatarName { get; set; }
    }

}
