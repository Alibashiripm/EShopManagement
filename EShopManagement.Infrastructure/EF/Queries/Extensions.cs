using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.DTOs.Product;
using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Entities.User;
 
namespace EShopManagement.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        #region Blogs And BlogComments
        public static AdminBlogsListDto AsAdminBlogsListDto(this Blog readModel)
          => new()
          {
              CreateDate = readModel._createDate.Value,
              Id = readModel.Id,
              ImageName = readModel.ImageName,
              Title = readModel._title.Value,
              UpdateDate = readModel._updateDate.Value
          };
        public static AdminBlogDto AsAdminBlogDto(this Blog readModel)
        {

            return new()
            {
                CreateDate = readModel._createDate.Value,
                Id = readModel.Id,
                ImageName = readModel.ImageName,
                Title = readModel._title.Value,
                UpdateDate = readModel._updateDate.Value,
                Content = readModel._content.Value,
                IsDeleted = readModel.IsDeleted,
                ShortDescription = readModel._shortDescription.Value,
                Tags = readModel.Tags
            };
        }
        public static AdminBlogCommentDto AsAdminBlogCommentDto(this BlogComment readModel)
        {

            return new()
            {
                BlogId = readModel.BlogId,
                CommentId = readModel.Id,
                Content = readModel._content.Value,
                IsConfirmed = readModel.IsConfirmed,
                UserId = readModel.UserId
            };
        }
        public static ClientBlogCommentDto AsClientBlogCommentDto(this BlogComment readModel)
        {

            return new()
            {
                CommentedFor = readModel.Blog._title.Value,
                Content = readModel._content.Value,
                UserAvatarName = readModel.User.UserAvatar,
                UserName = readModel.User.UserName,
            };
        }
        public static ClientBlogDto AsClientBlogDto(this Blog readModel)
        {
            return new()
            {
                ImageName = readModel.ImageName,
                Title = readModel._title.Value,
                Comments = readModel.BlogComments.Select(s => s.AsClientBlogCommentDto()).ToList(),
                Content = readModel._content.Value,
                ShortDescription = readModel._shortDescription.Value,
                Tags =  readModel.Tags 
            };
        }
        public static ClientBlogsListDto AsClientBlogsListDto(this Blog readModel)
        {
            return new()
            {
                ImageName = readModel.ImageName,
                Title = readModel._title.Value,
                ShortDescription = readModel._shortDescription.Value,
                CreateDate = readModel._createDate.Value,
                Id = readModel.Id,
                UpdateDate = readModel._updateDate.Value
            };
        }
        #endregion
        #region Order
        public static AdminDiscountDto AsAdminDiscountDto(this Discount readModel)
        {
            return new()
            {
                Id = readModel.Id,
                Code = readModel._discountCode.Value,
                EndDate = readModel._dateRange.EndDate,
                StartDate = readModel._dateRange.StartDate,
                IsDelete = readModel.IsDeleted,
                Percent = readModel._discountPercent.Value,
                UsableCount = readModel.UsableCount,
            };
        }
        public static OrderDetailDto AsOrderDetailDto(this OrderDetail readModel)
        {
            return new()
            {
                DetailId = readModel.Id,
                OrderId = readModel.OrderId,
                Price = readModel.Price,
                ProductId = readModel.ProductId
            };
        }
        public static OrderDto AsOrderDto(this Order readModel)
        {
            return new()
            {
                OrderId = readModel.Id,
                CreateDate = readModel._createDate.Value,
                IsFinaly = readModel.IsFinaly,
                OrderDetails = readModel?.OrderDetails?.Select(s => s.AsOrderDetailDto())?.ToList(),
                OrderSum = readModel.OrderSum,
                UserId = readModel.UserId
            };
        }
        #endregion
        #region Product
        public static AdminProductCategoryDto AsAdminProductCategoryDto(this ProductCategory readModel)
        {
            return new()
            {
                CategoryId = readModel.Id,
                IsDelete = readModel.IsDeleted,
                ParentId = readModel.ParentId,
                Title = readModel.Title
            };
        }
        public static AdminProductCommentDto AsAdminProductCommentDto(this ProductComment readModel)
        {
            return new()
            {
                CommentId = readModel.Id,
                UserId = readModel.UserId,
                Content = readModel._content.Value,
                CreateDate = readModel._createDate.Value,
                IsConfirmed = readModel.IsConfirmed,
                ProductId = readModel.ProductId

            };
        }
        public static AdminProductDto AsAdminProductDto(this Product readModel)
        {
            return new()
            {
                ProductId = readModel.Id,
                CategoryId = readModel.CategoryId,
                CellerId = readModel.CellerId,
                CreateDate = readModel._createDate.Value,
                Description = readModel._description.Value,
                FileName = readModel._fileName.Value,
                ImageName = readModel.ImageName,
                IsAvailable = readModel.IsAvailable,
                IsPremium = readModel.IsPremium,
                Price = readModel._price.Value,
                ShortDescription = readModel._shortDescription.Value,
                SubCategoryId = readModel.SubCategoryId,
                Tags =  readModel.Tags ,
                Title = readModel._title.Value,
                UpdateDate = readModel._updateDate.Value
            };
        }
        public static AdminPtoductsListDto AsAdminPtoductsListDto(this Product readModel)
        {
            return new()
            {
                ProductId = readModel.Id,
                CreateDate = readModel._createDate.Value,
                CategoryTitle = readModel.ProductCategory.Title,
                CellerUserName = readModel.Users.SingleOrDefault(u => u.Id == readModel.CellerId).UserName,
                SubCategoryTitle = readModel.ProductCategory.ProductCategories.SingleOrDefault(c => c.Id == readModel.SubCategoryId).Title,
                ImageName = readModel.ImageName,
                IsAvailable = readModel.IsAvailable,
                IsPremium = readModel.IsPremium,
                Price = readModel._price.Value,
                ShortDescription = readModel._shortDescription.Value,
                Title = readModel._title.Value,
                UpdateDate = readModel._updateDate.Value
            };
        }
        public static ClientProductCommentDto AsClientProductCommentDto(this ProductComment readModel)
        {
            return new()
            {
                Content = readModel._content.Value,
                CreateDate = readModel._createDate.Value.ToShortDateString(),
                ProductId = readModel.ProductId,
                UserAvatarName = readModel.User.UserAvatar,
                UserName = readModel.User.UserName

            };
        }
        public static ClientProductDto AsClientProductDto(this Product readModel)
        {
            return new()
            {
                ProductId = readModel.Id,
                CellerId = readModel.CellerId,
                CreateDate = readModel._createDate.Value.ToShortDateString(),
                Description = readModel._shortDescription.Value,
                FileName = readModel._fileName,
                ImageName = readModel.ImageName,
                IsAvailable = readModel.IsAvailable,
                IsPremium = readModel.IsPremium,
                Price = readModel._price.Value,
                ShortDescription = readModel._shortDescription.Value,
                Tags =  readModel.Tags ,
                Title = readModel._title.Value,
                UpdateDate = readModel._updateDate.Value.ToShortDateString(),
                CategoryTitle = readModel.ProductCategory.Title,
                SubCategoryTitle = readModel.ProductCategory.ProductCategories.SingleOrDefault(c => c.Id == readModel.SubCategoryId).Title,
            };
        }
        public static ClientProductsListDto AsClientProductsListDto(this Product readModel)
        {
            return new()
            {
                ProductId = readModel.Id,
                CreateDate = readModel._createDate.Value,
                ImageName = readModel.ImageName,
                ShortDescription = readModel._shortDescription.Value,
                Title = readModel._title.Value,
                Price = readModel._price.Value,
                IsPremium = readModel.IsPremium
            };
        }
        public static ProductCategoriesListDto AsProductCategoriesListDto(this ProductCategory readModel)
        {
            return new()
            {
                CategoryId = readModel.Id,
                CategoryParentId = readModel.ParentId.HasValue ? readModel.ParentId.Value : 0,
                CategoryTitle = readModel.Title
            };
        }
        #endregion
        #region User
        public static AdminAllRoleDto AsAdminAllRoleDto(this Role  readModel)
        {
            return new()
            {
                Id = readModel.Id,
                Title = readModel.Name
            };
        }
        public static AdminRoleUsersDto AsAdminRoleUsersDto(this Role  readModel)
        {
            return new()
            {
                Id = readModel.Id,
                Title = readModel.Name,
     
             };
        }
        public static AdminUserDto AsAdminUserDto(this User  readModel)
        {
            return new()
            {
                IsDelete = readModel.IsDeleted,
                IsPremiumMember = readModel.UserPremium._rangeDate.EndDate > DateTime.Now,
                RegistrationDate = readModel.RegistrationDate,
                UserAvatarName = readModel.UserAvatar ,
                UserId = readModel.Id,
                Email = readModel.Email,

                UserName = readModel.UserName
            };
        }
        public static AdminUsersListDto AsAdminUsersListDto(this User  readModel)
        {
            return new()
            {
                Email = readModel.Email,
                UserAvatarName = readModel.UserAvatar,
                UserId = readModel.Id,
                UserName = readModel.UserName
            };
        }
        public static ClientUserDto AsClientUserDto(this User  readModel)
        {
            bool isPremiumMember;
            if (readModel?.UserPremium == null) { isPremiumMember = false; }
            else { isPremiumMember = readModel?.UserPremium?._rangeDate.EndDate > DateTime.Now; }
            return new()
            {
                IsPremiumMember = isPremiumMember,
                RegistrationDate = readModel.RegistrationDate.ToShortDateString(),
                UserAvatarName = readModel.UserAvatar,
                PremiumExpireDate = readModel?.UserPremium?._rangeDate.EndDate.ToShortDateString(),
                Email = readModel.Email,
                UserName = readModel.UserName
            };
        }
        public static ClientEditUserAvatarDto AsClientEditUserAvatarDto(this User  readModel)
        {
     
            return new()
            {
                UserId= readModel.Id,
                UserAvatarName = readModel.UserAvatar,
              
            };
        }
        public static PaymentFactorDto AsPaymentFactorDto(this Order readModel)
        {
            return new()
            {
                CreateDate = readModel._createDate.Value,
                IsFinaly = readModel.IsFinaly,
                OrderId = readModel.Id,
                OrderSum = readModel.OrderSum,
                UserId = readModel.UserId,
                DetailDto = readModel.OrderDetails.Select(d => d.AsOrderDetailDto()).ToList(),
            };
        }   
     
        #endregion
    }
}
