using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Queries.User
{
    public class GetAllUsersForAdmin : IQuery<List<AdminUsersListDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;
        public string OrderBy { get; set; } = "RegistrationDate";
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty ;
        public string RoleTitle { get; set; } = string.Empty ;
        public bool  IsActived { get; set; }

    }  
}
