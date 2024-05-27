using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.DTOs.Product;
using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Domain.ValueObjects.Product;
using EShopManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        #region Blogs And BlogComments
        public static AdminBlogsListDto AsAdminBlogsListDto(this BlogReadModel readModel)
          => new()
          {
              CreateDate = readModel.CreateDate,
              Id = readModel.Id,
              ImageName = readModel.ImageName,
              Title = readModel.Title,
              UpdateDate = readModel.UpdateDate
          };
        public static AdminBlogDto AsAdminBlogDto(this BlogReadModel readModel)
        {

            return new()
            {
                CreateDate = readModel.CreateDate,
                Id = readModel.Id,
                ImageName = readModel.ImageName,
                Title = readModel.Title,
                UpdateDate = readModel.UpdateDate,
                Content = readModel.Content,
                IsDeleted = readModel.IsDeleted,
                ShortDescription = readModel.ShortDescription,
                Tags = TagsReadModel.ConvertToString(readModel.Tags)
            };
        }
        public static AdminBlogCommentDto AsAdminBlogCommentDto(this BlogCommentReadModel readModel)
        {

            return new()
            {
                BlogId = readModel.BlogId,
                CommentId = readModel.Id,
                Content = readModel.Content,
                IsConfirmed = readModel.IsConfirmed,
                UserId = readModel.UserId
            };
        }
        public static ClientBlogCommentDto AsClientBlogCommentDto(this BlogCommentReadModel readModel)
        {

            return new()
            {
                CommentedFor = readModel.Blog.Title,
                Content = readModel.Content,
                UserAvatarName = readModel.User.AvatarName,
                UserName = readModel.User.UserName,
            };
        }
        public static ClientBlogDto AsClientBlogDto(this BlogReadModel readModel)
        {
            return new()
            {
                ImageName = readModel.ImageName,
                Title = readModel.Title,
                Comments = readModel.BlogComments.Select(s => s.AsClientBlogCommentDto()).ToList(),
                Content = readModel.Content,
                ShortDescription = readModel.ShortDescription,
                Tags = TagsReadModel.ConvertToString(readModel.Tags)
            };
        }
        public static ClientBlogsListDto AsClientBlogsListDto(this BlogReadModel readModel)
        {
            return new()
            {
                ImageName = readModel.ImageName,
                Title = readModel.Title,
                ShortDescription = readModel.ShortDescription,
                CreateDate = readModel.CreateDate,
                Id = readModel.Id,
                UpdateDate = readModel.UpdateDate
            };
        }
        #endregion
        #region Order
        public static AdminDiscountDto AsAdminDiscountDto(this DiscountReadModel readModel)
        {
            return new()
            {
                Id = readModel.Id,
                Code = readModel.DiscountCode,
                EndDate = readModel._dateRange.EndDate,
                StartDate = readModel._dateRange.StartDate,
                IsDelete = readModel.IsDeleted,
                Percent = readModel.DiscountPercent,
                UsableCount = readModel.UsableCount,
            };
        }
        public static OrderDetailDto AsOrderDetailDto(this OrderDetailReadModel readModel)
        {
            return new()
            {
                DetailId = readModel.Id,
                OrderId = readModel.OrderId,
                Price = readModel.Price,
                ProductId = readModel.ProductId
            };
        }
        public static OrderDto AsOrderDto(this OrderReadModel readModel)
        {
            return new()
            {
                OrderId = readModel.Id,
                CreateDate = readModel.CreateDate,
                IsFinaly = readModel.IsFinaly,
                OrderDetails = readModel.OrderDetails.Select(s => s.AsOrderDetailDto()).ToList(),
                OrderSum = readModel.OrderSum,
                UserId = readModel.UserId
            };
        }
        #endregion
        #region Product
        public static AdminProductCategoryDto AsAdminProductCategoryDto(this ProductCategoryReadModel readModel)
        {
            return new()
            {
                CategoryId = readModel.Id,
                IsDelete = readModel.IsDeleted,
                ParentId = readModel.ParentId,
                Title = readModel.Title
            };
        }
        public static AdminProductCommentDto AsAdminProductCommentDto(this ProductCommentReadModel readModel)
        {
            return new()
            {
                CommentId = readModel.Id,
                UserId = readModel.UserId,
                Content = readModel.Content,
                CreateDate = readModel.CreateDate,
                IsConfirmed = readModel.IsConfirmed,
                ProductId = readModel.ProductId

            };
        }
        public static AdminProductDto AsAdminProductDto(this ProductReadModel readModel)
        {
            return new()
            {
                ProductId = readModel.Id,
                CategoryId = readModel.CategoryId,
                CellerId = readModel.CellerId,
                CreateDate = readModel.CreateDate,
                Description = readModel.Description,
                FileName = readModel.FileName,
                ImageName = readModel.ImageName,
                IsAvailable = readModel.IsAvailable,
                IsPremium = readModel.IsPremium,
                Price = readModel.Price,
                ShortDescription = readModel.ShortDescription,
                SubCategoryId = readModel.SubCategoryId,
                Tags = TagsReadModel.ConvertToString(readModel.Tags),
                Title = readModel.Title,
                UpdateDate = readModel.UpdateDate
            };
        }
        public static AdminPtoductsListDto AsAdminPtoductsListDto(this ProductReadModel readModel)
        {
            return new()
            {
                ProductId = readModel.Id,
                CreateDate = readModel.CreateDate,
                CategoryTitle = readModel.ProductCategory.Title,
                CellerUserName = readModel.Users.SingleOrDefault(u => u.Id == readModel.CellerId).UserName,
                SubCategoryTitle = readModel.ProductCategory.ProductCategories.SingleOrDefault(c => c.Id == readModel.SubCategoryId).Title,
                ImageName = readModel.ImageName,
                IsAvailable = readModel.IsAvailable,
                IsPremium = readModel.IsPremium,
                Price = readModel.Price,
                ShortDescription = readModel.ShortDescription,
                Title = readModel.Title,
                UpdateDate = readModel.UpdateDate
            };
        }
        public static ClientProductCommentDto AsClientProductCommentDto(this ProductCommentReadModel readModel)
        {
            return new()
            {
                Content = readModel.Content,
                CreateDate = readModel.CreateDate.ToShortDateString(),
                ProductId = readModel.ProductId,
                UserAvatarName = readModel.User.AvatarName,
                UserName = readModel.User.UserName

            };
        }
        public static ClientProductDto AsClientProductDto(this ProductReadModel readModel)
        {
            return new()
            {
                ProductId = readModel.Id,
                CellerId = readModel.CellerId,
                CreateDate = readModel.CreateDate.ToShortDateString(),
                Description = readModel.Description,
                FileName = readModel.FileName,
                ImageName = readModel.ImageName,
                IsAvailable = readModel.IsAvailable,
                IsPremium = readModel.IsPremium,
                Price = readModel.Price,
                ShortDescription = readModel.ShortDescription,
                Tags = TagsReadModel.ConvertToString(readModel.Tags),
                Title = readModel.Title,
                UpdateDate = readModel.UpdateDate.Value.ToShortDateString(),
                CategoryTitle = readModel.ProductCategory.Title,
                SubCategoryTitle = readModel.ProductCategory.ProductCategories.SingleOrDefault(c => c.Id == readModel.SubCategoryId).Title,
            };
        }
        public static ClientProductsListDto AsClientProductsListDto(this ProductReadModel readModel)
        {
            return new()
            {
                ProductId = readModel.Id,
                CreateDate = readModel.CreateDate,
                ImageName = readModel.ImageName,
                ShortDescription = readModel.ShortDescription,
                Title = readModel.Title,
                Price = readModel.Price,
            };
        }
        public static ProductCategoriesListDto AsProductCategoriesListDto(this ProductCategoryReadModel readModel)
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
        public static AdminAllRoleDto AsAdminAllRoleDto(this RoleReadModel readModel)
        {
            return new()
            {
                Id = readModel.Id,
                Title = readModel.Title
            };
        }
        public static AdminRoleUsersDto AsAdminRoleUsersDto(this RoleReadModel readModel)
        {
            return new()
            {
                Id = readModel.Id,
                Title = readModel.Title,
                UserIds = readModel.Users.Select(u => u.Id).ToList()
            };
        }
        public static AdminUserDto AsAdminUserDto(this UserReadModel readModel)
        {
            return new()
            {
                IsDelete = readModel.IsDeleted,
                IsPremiumMember = readModel.UserPremium.EndDate > DateTime.Now,
                RegistrationDate = readModel.RegistrationDate,
                UserAvatarName = readModel.AvatarName,
                UserId = readModel.Id,
                Email = readModel.Email,
                
                UserName = readModel.UserName
            };
        }
        public static AdminUsersListDto AsAdminUsersListDto(this UserReadModel readModel)
        {
            return new()
            {
                Email = readModel.Email,
                UserAvatarName = readModel.AvatarName,
                UserId = readModel.Id,
                UserName = readModel.UserName
            };
        }
        public static ClientUserDto AsClientUserDto(this UserReadModel readModel)
        {
            return new()
            {
                IsPremiumMember = readModel.UserPremium.EndDate > DateTime.Now,
                RegistrationDate = readModel.RegistrationDate.ToShortDateString(),
                UserAvatarName = readModel.AvatarName,
                PremiumExpireDate = readModel?.UserPremium?.EndDate.ToShortDateString(),
                Email = readModel.Email,
                UserName = readModel.UserName
            };
        } 
        public static PaymentFactorDto AsPaymentFactorDto(this OrderReadModel readModel)
        {
            return new()
            {
                CreateDate = readModel.CreateDate,
                IsFinaly = readModel.IsFinaly,
                OrderId = readModel.Id,
                OrderSum = readModel.OrderSum,
                UserId = readModel.UserId,
                DetailDto = readModel.OrderDetails.Select(d=>d.AsOrderDetailDto()).ToList(),            
            };
        }
        #endregion
    }
}
