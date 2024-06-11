using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Infrastructure.EF.Config;
 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 
namespace EShopManagement.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,
  IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserPremium> UserPremiums { get; set; }

        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }




        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<int>>()
               .HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<int>>()
               .HasKey(r => new { r.UserId, r.RoleId });

            var configuration = new ContextConfiguration();
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
            //modelBuilder.ApplyConfiguration<UserRole>(configuration);

            modelBuilder.ApplyConfiguration<UserPremium>(configuration);


            modelBuilder.ApplyConfiguration<UserDiscountCode>(configuration);

        }
    }
}