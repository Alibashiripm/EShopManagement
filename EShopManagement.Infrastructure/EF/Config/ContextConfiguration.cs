using EShopManagement.Domain.Entities;
using EShopManagement.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
 
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.ValueObjects.Blog;
using EShopManagement.Domain.ValueObjects.BlogComment;
using EShopManagement.Domain.ValueObjects.Order.Discount;
 
using EShopManagement.Domain.ValueObjects.Order;
using EShopManagement.Domain.ValueObjects.Product;
using EShopManagement.Domain.ValueObjects.User;
using EShopManagement.Domain.ValueObjects.ProductComment;

namespace EShopManagement.Infrastructure.EF.Config
{
    internal sealed class ContextConfiguration : IEntityTypeConfiguration<Blog>,
                                               IEntityTypeConfiguration<BlogComment>,
                                               IEntityTypeConfiguration<Discount>,
                                               IEntityTypeConfiguration<Order>,
                                               IEntityTypeConfiguration<OrderDetail>,
                                               IEntityTypeConfiguration<Product>,
                                               IEntityTypeConfiguration<ProductCategory>,
                                               IEntityTypeConfiguration<ProductComment>,
                                               IEntityTypeConfiguration<User>,
                                               IEntityTypeConfiguration<Role>,
                                               //IEntityTypeConfiguration<UserRole>,
                                               IEntityTypeConfiguration<UserPremium>,
                                               IEntityTypeConfiguration<UserDiscountCode>
                                          
        { 
                                    
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(pl => pl.Id);
 
            var blogTitleConverter = new ValueConverter<BlogTitle, string>(t => t.ToString(),
                t =>new BlogTitle(t));
            var blogContentConverter = new ValueConverter<BlogContent, string>(cnt => cnt.Value,
                cnt => new BlogContent(cnt)); 
            var blogShortDescriptionConverter = new ValueConverter<BlogShortDescription, string>(bsd => bsd.Value,
                bsd => new BlogShortDescription(bsd));
            var blogCreateDateConverter = new ValueConverter<BlogCreateDate, DateTime>(bcc => bcc.Value,
                bcc => new BlogCreateDate(bcc));
            var blogUpdateDateConverter = new ValueConverter<BlogUpdateTime, DateTime>(bcc => bcc.Value,
                bcc => new BlogUpdateTime(bcc));

            builder
                .Property(typeof(BlogTitle), "_title")
                .HasConversion(blogTitleConverter)
                .HasColumnName("Title");
            builder
                .Property(typeof(BlogContent), "_content")
                .HasConversion(blogContentConverter)
                .HasColumnName("Content"); 
            builder
                .Property(typeof(BlogShortDescription), "_shortDescription")
                .HasConversion(blogShortDescriptionConverter)
                .HasColumnName("ShortDescription");
            builder
                .Property(typeof(BlogCreateDate), "_createDate")
                .HasConversion(blogCreateDateConverter)
                .HasColumnName("CreateDate"); 
            builder
                .Property(typeof(BlogUpdateTime), "_updateDate")
                .HasConversion(blogUpdateDateConverter)
                .HasColumnName("UpdateTime");

            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.HasMany(b => b.BlogComments);
            builder.ToTable("Blogs");
        }
        public void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.HasKey(pl => pl.Id);
            var blogCommentContentConverter = new ValueConverter<BlogCommentContent, string>(cnt => cnt.Value,
            cnt => new BlogCommentContent(cnt));

            var blogCommentCreateDateConverter = new ValueConverter<BlogCommentCreateDate, DateTime>(bcc => bcc.Value,
                        bcc => new BlogCommentCreateDate(bcc));
                 
            builder
               .Property(typeof(BlogCommentContent), "_content")
               .HasConversion(blogCommentContentConverter)
               .HasColumnName("Content"); 
    
            builder
                .Property(typeof(BlogCommentCreateDate), "_createDate")
                .HasConversion(blogCommentCreateDateConverter)
                .HasColumnName("CreateDate");
               
            builder.HasOne(b => b.Blog).WithMany(b=>b.BlogComments).HasForeignKey(f=>f.BlogId);
 
             builder.ToTable("BlogComments");
        }
        private static DiscountDateRange ConvertToDiscountDateRange(string str)
        {
            var parts = str.Split('|');
            return new DiscountDateRange(DateTime.Parse(parts[0]), DateTime.Parse(parts[1]));
        }
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(pl => pl.Id);
            var discountCodetConverter = new ValueConverter<DiscountCode, string>(cnt => cnt.Value,
            cnt => new DiscountCode(cnt));

            var discountDateRangeConverter = new ValueConverter<DiscountDateRange, string>(
               bcc => $"{bcc.StartDate:o}|{bcc.EndDate:o}",
               str => ConvertToDiscountDateRange(str));
            var discountPercentConverter = new ValueConverter<DiscountPercent, int>(cnt => cnt.Value,
            cnt => new DiscountPercent(cnt));
 
            builder
               .Property(typeof(DiscountCode), "_discountCode")
               .HasConversion(discountCodetConverter)
               .HasColumnName("Code");
            builder
               .Property(typeof(DiscountPercent), "_discountPercent")
               .HasConversion(discountPercentConverter)
               .HasColumnName("Percent");
            builder
               .Property(typeof(DiscountDateRange), "_dateRange")
               .HasConversion(discountDateRangeConverter)
               .HasColumnName("DateRange");
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.ToTable("Discounts");

        } 
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(pl => pl.Id);
            var orderCreateDateConverter = new ValueConverter<OrderCreateDate, DateTime>(bcc => bcc.Value,
                        bcc => new OrderCreateDate(bcc));
            builder
                     .Property(typeof(OrderCreateDate), "_createDate")
                     .HasConversion(orderCreateDateConverter)
                     .HasColumnName("CreateDate");
            builder.HasMany<OrderDetail>();
            builder.HasQueryFilter( b => !b.IsDeleted);
            builder.ToTable("Orders");
        }
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(pl => pl.Id);
            builder.HasOne(o=>o.Order).WithMany(od=>od.OrderDetails).HasForeignKey(f=>f.OrderId);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.ToTable("OrderDetails");
        }
       
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pl => pl.Id);

            var productTitleConverter = new ValueConverter<ProductTitle, string>(t => t.ToString(),
                t => new ProductTitle(t));
            var prouctDescriptionConverter = new ValueConverter<ProductDescription, string>(cnt => cnt.Value,
                cnt => new ProductDescription(cnt));  
            var prouctShortDescriptionConverter = new ValueConverter<ProductShortDescription, string>(cnt => cnt.Value,
                cnt => new ProductShortDescription(cnt));
            var productCreateDateConverter = new ValueConverter<ProductCreateDate, DateTime>(bcc => bcc.Value,
                bcc => new ProductCreateDate(bcc));
            var productUpdateDateConverter = new ValueConverter<ProductUpdateDate, DateTime>(bcc => bcc.Value,
                bcc => new ProductUpdateDate(bcc));  
            var productFileNameConverter = new ValueConverter<ProductFileName, string>(cnt => cnt.Value,
                cnt => new ProductFileName(cnt)); 
            var productpriceConverter = new ValueConverter<ProductPrice, decimal>(cnt => cnt.Value,
                cnt => new ProductPrice(cnt));

            builder
                .Property(typeof(ProductPrice), "_price")
                .HasConversion(productpriceConverter)
                .HasColumnName("Price");  
            builder
                .Property(typeof(ProductTitle), "_title")
                .HasConversion(productTitleConverter)
                .HasColumnName("Title");
            builder
                .Property(typeof(ProductFileName), "_fileName")
                .HasConversion(productFileNameConverter)
                .HasColumnName("FileName");
            builder
                .Property(typeof(ProductDescription), "_description")
                .HasConversion(prouctDescriptionConverter)
                .HasColumnName("Description");
            builder
                .Property(typeof(ProductShortDescription), "_shortDescription")
                .HasConversion(prouctShortDescriptionConverter)
                .HasColumnName("ShortDescription");
            builder
                .Property(typeof(ProductCreateDate), "_createDate")
                .HasConversion(productCreateDateConverter)
                .HasColumnName("CreateDate");
            builder
                .Property(typeof(ProductUpdateDate), "_updateDate")
                .HasConversion(productUpdateDateConverter)
                .HasColumnName("UpdateDate");

            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.HasMany(b => b.ProductComments);
            builder.HasMany(b => b.Users);
            builder.HasMany(b => b.OrderDetails);
            builder.HasOne(b => b.ProductCategory).WithMany(p=>p.Products).HasForeignKey(f=>f.CategoryId);
            builder.HasOne(b => b.ProductCategory).WithMany(p=>p.Products).HasForeignKey(f=>f.SubCategoryId);
            builder.ToTable("Products");

        }
        private static PremiumRangeDate ConvertToPremiumDateRange(string str)
        {
            var parts = str.Split('|');
            return new PremiumRangeDate(DateTime.Parse(parts[0]), DateTime.Parse(parts[1]));
        }
        public void Configure(EntityTypeBuilder<UserPremium> builder)
        {
            builder.HasKey(pl => pl.Id);
            var premiumRangeDateConverter = new ValueConverter<PremiumRangeDate, string>(
                 bcc => $"{bcc.StartDate:o}|{bcc.EndDate:o}",
                 str => ConvertToPremiumDateRange(str));
        
            builder
                         .Property(p=>p._rangeDate)
                         .HasConversion(premiumRangeDateConverter)
                         .HasColumnName("DateRange");
            builder.HasOne(u => u.User).WithOne(u => u.UserPremium).HasForeignKey<UserPremium>(f=>f.UserId);
            builder.ToTable("UserPremiums");
        }
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pl => pl.Id);
            builder.HasMany(c => c.Products).WithOne(c => c.ProductCategory).HasForeignKey(f => f.CategoryId).OnDelete(DeleteBehavior.Cascade); 
            builder.HasMany(pc => pc.ProductCategories)
                .WithOne()
                .HasForeignKey(pc => pc.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasQueryFilter(b=>!b.IsDeleted);
            builder.ToTable("ProductCategories");
        }
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.HasKey(pl => pl.Id);
            var productCommentContentConverter = new ValueConverter<ProductCommentContent, string>(cnt => cnt.Value,
            cnt => new ProductCommentContent(cnt));

            var productCommentCreateDateConverter = new ValueConverter<ProductCommentCreateDate, DateTime>(bcc => bcc.Value,
                        bcc => new ProductCommentCreateDate(bcc));

            builder
               .Property(typeof(ProductCommentContent), "_content")
               .HasConversion(productCommentContentConverter)
               .HasColumnName("Content");

            builder
                .Property(typeof(ProductCommentCreateDate), "_createDate")
                .HasConversion(productCommentCreateDateConverter)
                .HasColumnName("CreateDate");

            builder.HasOne(b => b.Product).WithMany(b => b.ProductComments).HasForeignKey(f => f.ProductId);
            builder.HasOne(b => b.User).WithMany(b => b.ProductComments).HasForeignKey(f => f.UserId);
             builder.ToTable("ProductComments");
        } 
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u=>u.UserPremium).WithOne(u=>u.User).HasForeignKey<UserPremium>(f=>f.UserId);
            builder.HasMany(u=>u.Products).WithMany(u=>u.Users);
            builder.HasMany(u => u.ProductComments).WithOne(u => u.User).HasForeignKey(f => f.UserId);
            builder.HasMany(u => u.BlogComments).WithOne(u => u.User).HasForeignKey(f => f.UserId); 

            builder.ToTable("Users");
        }

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
        }

        //public void Configure(EntityTypeBuilder<UserRole> builder)
        //{
    
        //    builder.ToTable("UserRoles");
        //}
        public void Configure(EntityTypeBuilder<UserDiscountCode> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasOne(u => u.User).WithMany(u => u.UserDiscountCodes).HasForeignKey(f => f.UserId);
             builder.ToTable("UserDiscountCodes");
        }
    }
}
