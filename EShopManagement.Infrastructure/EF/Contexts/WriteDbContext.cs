
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;
 

namespace EShopManagement.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments{ get; set; }
        public DbSet<Discount> Discounts{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductCategory> ProductCategories{ get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<RoleClaim> RoleClaims{ get; set; }
        public DbSet<UserClaim> UserClaims{ get; set; }
        public DbSet<UserLogin> UserLogins{ get; set; }
        public DbSet<UserPremium> UserPremiums { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }
        public DbSet<UserToken> UserTokens{ get; set; }
        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }




        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TravelerCheckList");
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<Blog>(configuration);
            modelBuilder.ApplyConfiguration<BlogComment>(configuration);
            modelBuilder.ApplyConfiguration<Discount>(configuration);
            modelBuilder.ApplyConfiguration<Order>(configuration);
            modelBuilder.ApplyConfiguration<OrderDetail>(configuration);
            modelBuilder.ApplyConfiguration<Product>(configuration);
            modelBuilder.ApplyConfiguration<ProductCategory>(configuration);
            modelBuilder.ApplyConfiguration<ProductComment>(configuration);
            modelBuilder.ApplyConfiguration<User>(configuration);
            modelBuilder.ApplyConfiguration<Role>(configuration);
            modelBuilder.ApplyConfiguration<RoleClaim>(configuration);
            modelBuilder.ApplyConfiguration<UserClaim>(configuration);
            modelBuilder.ApplyConfiguration<UserLogin>(configuration);
            modelBuilder.ApplyConfiguration<UserPremium>(configuration);
            modelBuilder.ApplyConfiguration<UserRefreshToken>(configuration);
            modelBuilder.ApplyConfiguration<UserRole>(configuration);
            modelBuilder.ApplyConfiguration<UserToken>(configuration);
            modelBuilder.ApplyConfiguration<UserDiscountCode>(configuration);
          
        }
    }
}
