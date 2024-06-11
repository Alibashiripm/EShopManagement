using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.User
{
    public class GetUserAavtarForClient: IQuery<ClientEditUserAvatarDto>
    {
        public int UserId { get; set; }
    }  
}
