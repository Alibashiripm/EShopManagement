using Microsoft.AspNetCore.Identity;

namespace EShopManagement.Domain.Entities.User
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public UserLogin()
        {
            LoggedOn = DateTime.Now;
        }
        public User User { get; set; }
        public DateTime LoggedOn { get; set; }
    }
}
