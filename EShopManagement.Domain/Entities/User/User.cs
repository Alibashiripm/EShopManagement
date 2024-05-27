using EShopManagement.Domain.Entities.Product;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace EShopManagement.Domain.Entities.User
{
    public class User : IdentityUser<int>
    {
       
        public string ActiveCode { get; set; }
     
        public string UserAvatar { get; set; }
     
        public UserPremium UserPremium { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserLogin> Logins { get; set; }
        public ICollection<UserClaim> Claims { get; set; }
        public ICollection<UserToken> Tokens { get; set; }
        public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
        public ICollection<Product.Product> Products { get; set; }
        public ICollection<Product.ProductComment>ProductComments { get; set; }
        public ICollection<Blog.BlogComment>BlogComments { get; set; }
        public ICollection<UserDiscountCode> UserDiscountCodes { get; set; }
        public bool IsDeleted { get; private set; }
 
        internal User(string userName, string email,  string userAvatar, string activeCode)
        {
            UserName = userName;
            Email = email;
             UserAvatar = userAvatar;
            ActiveCode = activeCode;

        }
        public User()
        {
            
        }

        public void SoftDelete()
        {
        IsDeleted = true;
        }   
     
    }
}
