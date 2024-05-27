using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.User
{
    public class GetUserProfileForClient: IQuery<ClientUserDto>
    {
        public int UserId { get; set; }
    }  
}
