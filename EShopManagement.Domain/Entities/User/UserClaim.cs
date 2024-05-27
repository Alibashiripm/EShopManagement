using Microsoft.AspNetCore.Identity;

namespace EShopManagement.Domain.Entities.User
{
    public class UserClaim : IdentityUserClaim<int> 
    {
        public User User { get; set; }
    }
}
