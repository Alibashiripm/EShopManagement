using EShopManagement.Domain.Entities.Product;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace EShopManagement.Domain.Entities.User
{
    public class User : IdentityUser<int>
    {
       
        public string ActiveCode { get; set; }= Guid.NewGuid().ToString(); 

        public string UserAvatar { get; set; } = "Defult.jpg";
        public DateTime RegistrationDate { get; set; }


        public UserPremium  UserPremium { get; set; }
        public ICollection<Product.Product> Products { get; set; }
        public ICollection<Product.ProductComment>ProductComments { get; set; }
        public ICollection<Blog.BlogComment>BlogComments { get; set; }
        public ICollection<UserDiscountCode> UserDiscountCodes { get; set; }
        public bool IsDeleted { get; private set; }
 
        internal User(string userName, string email )
        {
            UserName = userName;
            Email = email;
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
