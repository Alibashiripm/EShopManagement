using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Role
{
    public class GetRoleUsers:IQuery<List<AdminRoleUsersDto>>
    {
        public int RoleId { get; set; }
    }
}
