using Microsoft.AspNetCore.Identity;

namespace EShopManagement.Domain.Entities.User
{
    public class UserToken : IdentityUserToken<long> 
    {
        public UserToken()
        {
            GeneratedTime = DateTime.Now;
        }

        public User User { get; set; }
        public DateTime GeneratedTime { get; set; }

    }
}
