using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Queries.User
{
   
    public class LoginUser : IQuery<SignInResult>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
