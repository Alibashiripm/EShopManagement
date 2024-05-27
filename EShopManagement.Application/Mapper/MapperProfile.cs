
using AutoMapper;
using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.ValueObjects.Blog;
using EShopManagement.Domain.ValueObjects.Product;
using EShopManagement.Domain.ValueObjects.ProductComment;

namespace EShopManagement.Application.Mapper
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            #region Blog
            CreateMap<Blog, AdminBlogDto>()
          .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src._title.Value))
          .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src._content.Value))
          .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src._shortDescription.Value))
          .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
          .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src._createDate.Value))
          .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src._updateDate.Value))
          .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted)).ReverseMap();
            #endregion
            #region Blog Comment
            CreateMap<BlogComment, ClientBlogCommentDto>()
          .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src._content.Value))
          .ForMember(dest => dest.CommentedFor, opt => opt.MapFrom(src => src.Blog._title.Value))
          .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
          .ForMember(dest => dest.UserAvatarName, opt => opt.MapFrom(src => src.User.UserAvatar)).ReverseMap(); 
         
            CreateMap<BlogComment, ClientBlogLeaveCommentDto>()
          .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src._content.Value))
          .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.Blog.Id))
          .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id)).ReverseMap();
            #endregion
            #region Order
            CreateMap<Order, OrderDto>()
        .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src._createDate.Value)).ReverseMap();
            #endregion
            #region OrderDetail
            CreateMap<OrderDetailDto, OrderDetail>()
         .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
         .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
         .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
         .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => false)).ReverseMap();

            #endregion
            #region Product
            
                // Mapping from Product to AdminProductDto
                CreateMap<Product, AdminProductDto>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src._title.Value))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src._description.Value))
                    .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src._shortDescription.Value))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src._fileName != null ? src._fileName.Value : null))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src._price.Value))
                    .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src._createDate.Value))
                    .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src._updateDate != null ? src._updateDate.Value : (DateTime?)null));

                // Mapping from AdminProductDto to Product
                CreateMap<AdminProductDto, Product>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                    .ForMember(dest => dest._title, opt => opt.MapFrom(src => new ProductTitle(src.Title)))
                    .ForMember(dest => dest._description, opt => opt.MapFrom(src => new ProductDescription(src.Description)))
                    .ForMember(dest => dest._shortDescription, opt => opt.MapFrom(src => new ProductShortDescription(src.ShortDescription)))
                    .ForMember(dest => dest._fileName, opt => opt.MapFrom(src => src.FileName != null ? new ProductFileName(src.FileName) : null))
                    .ForMember(dest => dest._price, opt => opt.MapFrom(src => new ProductPrice(src.Price)))
                    .ForMember(dest => dest._createDate, opt => opt.MapFrom(src => new ProductCreateDate(src.CreateDate)))
                    .ForMember(dest => dest._updateDate, opt => opt.MapFrom(src => src.UpdateDate != null ? new ProductUpdateDate(src.UpdateDate.Value) : (ProductUpdateDate?)null));

            #endregion
            #region Product Comment
            // Mapping from AdminProductCommentDto to ProductComment
            CreateMap<AdminProductCommentDto, ProductComment>()
                .ForMember(dest => dest._content, opt => opt.MapFrom(src => new ProductCommentContent(src.Content)))
                .ForMember(dest => dest._createDate, opt => opt.MapFrom(src => new ProductCommentCreateDate(src.CreateDate)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.IsConfirmed, opt => opt.MapFrom(src => src.IsConfirmed));

            // Mapping from ProductComment to AdminProductCommentDto
            CreateMap<ProductComment, AdminProductCommentDto>()
                .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src._content.Value))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src._createDate.Value))
                .ForMember(dest => dest.IsConfirmed, opt => opt.MapFrom(src => src.IsConfirmed))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            #endregion
            #region Product Category
            // Mapping from ProductCategory to AdminProductCategoryDto
            CreateMap<ProductCategory, AdminProductCategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId));

            // Mapping from AdminProductCategoryDto to ProductCategory
            CreateMap<AdminProductCategoryDto, ProductCategory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDelete))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.ProductCategories, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());
            #endregion
        }
    }
}
