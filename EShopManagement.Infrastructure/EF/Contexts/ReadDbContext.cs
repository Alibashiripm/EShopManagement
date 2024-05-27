using EShopManagement.Domain.Entities.User;
using EShopManagement.Infrastructure.EF.Config;
using EShopManagement.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
 
namespace EShopManagement.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<BlogCommentReadModel> BlogComments{ get; set; }
        public DbSet<BlogReadModel> Blogs{ get; set; }
        public DbSet<DiscountReadModel> Discounts{ get; set; }
        public DbSet<OrderReadModel> Orders{ get; set; }
        public DbSet<OrderDetailReadModel> OrderDetails{ get; set; }
        public DbSet<ProductCategoryReadModel> ProductCategories{ get; set; }
        public DbSet<ProductReadModel> Products{ get; set; }
        public DbSet<ProductCommentReadModel> ProductComments{ get; set; }
        public DbSet<RoleReadModel> Roles{ get; set; }
        public DbSet<UserReadModel> Users { get; set; }
        public DbSet<UserPremiumReadModel> UserPremiums { get; set; }
        public DbSet<UserDiscountCodeReadModel> UserDiscountCodes { get; set; }



        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<BlogCommentReadModel>(configuration);
            modelBuilder.ApplyConfiguration<BlogReadModel>(configuration);
            modelBuilder.ApplyConfiguration<DiscountReadModel>(configuration);
            modelBuilder.ApplyConfiguration<OrderReadModel>(configuration);
            modelBuilder.ApplyConfiguration<OrderDetailReadModel>(configuration);
            modelBuilder.ApplyConfiguration<ProductCategoryReadModel>(configuration);
            modelBuilder.ApplyConfiguration<ProductReadModel>(configuration);
            modelBuilder.ApplyConfiguration<ProductCommentReadModel>(configuration);
            modelBuilder.ApplyConfiguration<RoleReadModel>(configuration);
            modelBuilder.ApplyConfiguration<UserReadModel>(configuration);
            modelBuilder.ApplyConfiguration<UserPremiumReadModel>(configuration);     
            modelBuilder.ApplyConfiguration<UserDiscountCodeReadModel>(configuration);     
        }
    }
}