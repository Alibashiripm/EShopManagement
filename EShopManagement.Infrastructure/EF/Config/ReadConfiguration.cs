
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EShopManagement.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EShopManagement.Domain.ValueObjects.Order.Discount;
using EShopManagement.Domain.Entities.User;


namespace EShopManagement.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<BlogCommentReadModel>,
                                                IEntityTypeConfiguration<BlogReadModel>,
                                                IEntityTypeConfiguration<DiscountReadModel>,
                                                IEntityTypeConfiguration<OrderDetailReadModel>,
                                                IEntityTypeConfiguration<OrderReadModel>,
                                                IEntityTypeConfiguration<ProductCategoryReadModel>,
                                                IEntityTypeConfiguration<ProductCommentReadModel>,
                                                 IEntityTypeConfiguration<ProductReadModel>,
                                                IEntityTypeConfiguration<RoleReadModel>,
                                                IEntityTypeConfiguration<UserReadModel>,
                                                IEntityTypeConfiguration<UserDiscountCodeReadModel>,
                                                IEntityTypeConfiguration<UserPremiumReadModel>


    {
        public void Configure(EntityTypeBuilder<BlogCommentReadModel> builder)
        {
            builder.ToTable("BlogComments");
            builder.HasKey(k => k.Id);
            builder.HasOne(c => c.Blog).WithMany(b => b.BlogComments).HasForeignKey(f => f.BlogId);
            builder.HasOne(c => c.User).WithMany(b => b.BlogComments).HasForeignKey(f => f.UserId);
            builder.HasQueryFilter(b => b.IsConfirmed);

        }

        public void Configure(EntityTypeBuilder<BlogReadModel> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(k => k.Id);

            var tagsConverter = new ValueConverter<TagsReadModel, string>(
                v => TagsReadModel.ConvertToString(v),
                v => TagsReadModel.GetTags(v));

            builder.Property(p => p.Tags).HasConversion(tagsConverter);

            builder.HasMany(b => b.BlogComments);
            builder.HasQueryFilter(b => !b.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<DiscountReadModel> builder)
        {
            builder.HasKey(pl => pl.Id);
            var discountDateRangeConverter = new ValueConverter<DiscountDateRange, DateRangeTuple>(
            bcc => new DateRangeTuple { StartDate = bcc.StartDate, EndDate = bcc.EndDate },
            tuple => new DiscountDateRange(tuple.StartDate, tuple.EndDate));
            builder
                        .Property(typeof(DiscountDateRange), "_dateRange")
                        .HasConversion(discountDateRangeConverter)
                        .HasColumnName("DateRange");
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.ToTable("Discounts");

        }
        public void Configure(EntityTypeBuilder<OrderDetailReadModel> builder)
        {
            builder.HasKey(pl => pl.Id);
            builder.HasOne(o => o.Order).WithMany(od => od.OrderDetails).HasForeignKey(f => f.OrderId);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.ToTable("OrderDetails");
        }
        public void Configure(EntityTypeBuilder<OrderReadModel> builder)
        {
            builder.HasKey(pl => pl.Id);
   
            builder.HasMany<OrderDetailReadModel>();
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.ToTable("Orders");
        }
        public void Configure(EntityTypeBuilder<ProductCategoryReadModel> builder)
        {
            builder.HasKey(pl => pl.Id);
            builder.HasMany(c => c.Products).WithOne(c => c.ProductCategory).HasForeignKey(f => f.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(pc => pc.ProductCategories)
                .WithOne()
                .HasForeignKey(pc => pc.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.ToTable("ProductCategories");
        }
        public void Configure(EntityTypeBuilder<ProductCommentReadModel> builder)
        {
            builder.HasKey(pl => pl.Id);
            builder.HasOne(b => b.Product).WithMany(b => b.ProductComments).HasForeignKey(f => f.ProductId);
            builder.HasOne(b => b.User).WithMany(b => b.ProductComments).HasForeignKey(f => f.UserId);
            builder.HasQueryFilter(b => b.IsConfirmed);
            builder.HasQueryFilter(u => !u.IsDeleted);

            builder.ToTable("ProductComments");

        }

        public void Configure(EntityTypeBuilder<ProductReadModel> builder)
        {
            builder.HasKey(k => k.Id);

            var tagsConverter = new ValueConverter<TagsReadModel, string>(
                v => TagsReadModel.ConvertToString(v),
                v => TagsReadModel.GetTags(v));

            builder.Property(p => p.Tags).HasConversion(tagsConverter);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.HasMany(b => b.ProductComments);
            builder.HasMany(b => b.Users);
            builder.HasMany(b => b.OrderDetails);
            builder.HasOne(b => b.ProductCategory).WithMany(p => p.Products).HasForeignKey(f => f.CategoryId);
            builder.HasOne(b => b.ProductCategory).WithMany(p => p.Products).HasForeignKey(f => f.SubCategoryId);
            builder.HasQueryFilter(u => !u.IsDeleted);

            builder.ToTable("Products");
        }
        public void Configure(EntityTypeBuilder<RoleReadModel> builder)
        {
            builder.HasQueryFilter(u => !u.IsDeleted);

            builder.ToTable("Roles");
        }
        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.HasOne(u => u.UserPremium).WithOne(u => u.User).HasForeignKey<UserPremium>(f => f.UserId);
            builder.HasMany(u => u.Products).WithMany(u => u.Users);
            builder.HasMany(u => u.ProductComments).WithOne(u => u.User).HasForeignKey(f => f.UserId);
            builder.HasMany(u => u.BlogComments).WithOne(u => u.User).HasForeignKey(f => f.UserId);
            builder.HasQueryFilter(u => u.IsActived);
            builder.HasQueryFilter(u => !u.IsDeleted);
            builder.ToTable("Users");
        }
        public void Configure(EntityTypeBuilder<UserPremiumReadModel> builder)
        {
            builder.HasKey(pl => pl.Id);    
            builder.HasOne(u => u.User).WithOne(u => u.UserPremium).HasForeignKey<UserPremium>(f => f.UserId);
            builder.HasQueryFilter(u => !u.IsDeleted);

            builder.ToTable("UserPremiums");
        }

        public void Configure(EntityTypeBuilder<UserDiscountCodeReadModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasOne(u => u.User).WithMany(u => u.UserDiscountCodes).HasForeignKey(f => f.UserId);
            builder.ToTable("UserDiscountCodes");
        }
    }
    }
 
