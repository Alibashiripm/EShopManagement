using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Queries.Role
{
    public class GetAllRoles :IQuery<List<AdminAllRoleDto>>
    {
    }
}
