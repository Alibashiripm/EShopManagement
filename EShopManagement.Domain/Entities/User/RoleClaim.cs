using Microsoft.AspNetCore.Identity;


namespace EShopManagement.Domain.Entities.User
{
    public class RoleClaim : IdentityRoleClaim<int> 
    {
       
        public DateTime CreatedClaim { get; set; }
        public Role Role { get; set; }

    }
}
