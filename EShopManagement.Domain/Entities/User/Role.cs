using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace EShopManagement.Domain.Entities.User
{
    public class Role:IdentityRole<int>
    {
        public ICollection<RoleClaim> Claims { get; set; }
        public ICollection<UserRole> Users { get; set; }
        public bool IsDelete { get; private set; }

        public Role()
        {
            
        }
        internal Role(string name)
        {
            Name = name;
        }

        public void SoftDelete()
        {
            IsDelete = true;
        }
    }
}
