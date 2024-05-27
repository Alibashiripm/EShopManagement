using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.User
{
    public class GetUserForAdmin : IQuery<AdminUserDto>
    {
        public int UserId { get; set; }
    }
}
