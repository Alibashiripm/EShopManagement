namespace EShopManagement.Infrastructure.EF.Models
{
    internal class UserReadModel
    {
      
        public int Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ActiveCode { get; set; }
        public string RoleTitle { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string SecurityStamp { get; set; }
        public string AvatarName { get; set; }
        public bool IsDeleted  { get; set; }
        public bool IsActived  { get; set; }
        public UserPremiumReadModel UserPremium  { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<BlogCommentReadModel> BlogComments { get; set; }
        public ICollection<ProductCommentReadModel> ProductComments { get; set; }
        public ICollection<ProductReadModel> Products { get; set; }
        public ICollection<RoleReadModel> Roles { get; set; }
        public ICollection<UserDiscountCodeReadModel> UserDiscountCodes{ get; set; }


    }
}
